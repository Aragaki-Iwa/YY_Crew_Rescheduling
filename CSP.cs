using System;
using System.Collections.Generic;
using System.Collections;
using System.Threading;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using ILOG.Concert;
using ILOG.CPLEX;


namespace CG_CSP_1440
{
    class CSP
    {
        public double OBJVALUE;//总的目标函数值Z
        public List<Pairing> OptColumnSet;//Opt-最优解
        public List<Pairing> ColumnPool = new List<Pairing>();
        public Cplex masterModel;

        //参数
        int num_AddColumn = 10;
        double GAP = 0.01;

        private List<Pairing> PathSet;//所有的交路集合，列池
        private List<double> CoefSet;//Cj
        private List<double> AccumuWorkSet;
        private List<double> ObjCoefSet;//
        private List<int[]> A_Matrix;//aji
        private List<INumVar> DvarSet;

        int initialPath_num;
        int trip_num;
        int realistic_trip_num;
        NetWork Network;
        List<Node> NodeSet;
        List<Node> TripList;

        IObjective Obj;
        IRange[] Constraint;

        List<IRange> ct_nb;
        IRange[][] Ct_crewNum;
        IRange[] Ct_cover;
        int NUMBER_CREW;
        int NUMBER_ROUTE;

        //至始至终都只有一个实体，求解过程中只是改变各属性值
        RCSPP R_C_SPP;
        TreeNode root_node;
        List<int> best_feasible_solution; //元素值为1的为决策变量的下标。只记录一个可行解，不管有多个目标值相同的解  

        
        public CSP(NetWork network, int numOfCrew, int numOfRoute)
        {
            this.Network = network;
            NodeSet = network.NodeSet;
            TripList = network.TripList;
            Topological2 topo;
            R_C_SPP = new RCSPP(this.Network , out topo);

            NUMBER_CREW = numOfCrew;
            NUMBER_ROUTE = numOfRoute;
        }

        /// <summary>分支定价
        /// 从指定的初始解作为上界开始
        /// </summary>
        /// <param name="IS"></param>
        public void Branch_and_Price(InitialSolution IS)//initial solution初始解
        {
            Stopwatch sw = new Stopwatch();                           //stopwatch获取以每秒计时周期数表示的计时器频率，即计时
            sw.Start();

            //Build_RMP(IS);
            Build_RMP_YY(IS); //20191004
            WriteModelToFIle();

            root_node = new TreeNode();
            CG(ref root_node);                                        //ref-引用，修改参数变量的修改也将导致原来变量的值被修改

            sw.Stop();
            Console.WriteLine("根节点求解时间： " + sw.Elapsed.TotalSeconds);

            best_feasible_solution = new List<int>();                //最优解
            //RecordFeasibleSolution(root_node, ref best_feasible_solution);
            RecordFeasibleSolution(ref best_feasible_solution);
            double UB = IS.initial_ObjValue;//int.MaxValue;
            double LB = root_node.obj_value;

            sw.Restart();

            //Branch_and_Bound(root_node , LB , UB);
            // 不分支定界了，转化为整数规划求解

            sw.Stop();
            Console.WriteLine("分支定价共花费时间：" + sw.Elapsed.TotalSeconds);
        }
        /// <summary>建立最初的RMP
        /// 依据初始解
        /// </summary>
        /// <param name="IS"></param>
        public void Build_RMP(InitialSolution IS)//主问题的建模
        {
            initialPath_num = IS.PathSet.Count;
            trip_num = TripList.Count;
            realistic_trip_num = NetWork.num_Physical_trip;

            DvarSet = new List<INumVar>();//x
            CoefSet = new List<double>();//cij
            AccumuWorkSet = new List<double>();//每条交路累计工作时间
            ObjCoefSet = new List<double>();
            A_Matrix = new List<int[]>();//aij
            PathSet = new List<Pairing>();//列池
            //int n = 196;//n代表的是整个高一车队每天所需要的乘务员和乘务长的总和


            CoefSet = IS.Coefs;//IS初始解
            AccumuWorkSet = IS.AccumuWorkSet;
            A_Matrix = IS.A_Matrix;
            PathSet = IS.PathSet;
            ObjCoefSet = IS.ObjCoefs;

            //for(int k = 0 ; k < IS.Coefs.Count ; k++)
            //{
            //    ObjCoefSet.Add(Network.GetObjCoef(IS.AccumuWorkSet[k] , IS.Coefs[k]));
            //}

            foreach(var p in PathSet)
            {
                ColumnPool.Add(p);
            }

            int i, j;
            masterModel = new Cplex();
            Obj = masterModel.AddMinimize();
            Constraint = new IRange[realistic_trip_num];//这种I打头的都是cplex里面的东西
            /**按行建模**/
            //vars and obj function
            for(j = 0 ; j < initialPath_num ; j++)//定义决策变量和目标函数
            {
                INumVar var = masterModel.NumVar(0 , 1 , NumVarType.Float);//INumVar-cplex里面的，定义决策变量。后面括号中的意思是定义var是0-1之间的浮点值
                DvarSet.Add(var);
                Obj.Expr = masterModel.Sum(Obj.Expr , masterModel.Prod(CoefSet[j] , DvarSet[j]));//后面的小括号里面是一个cij*xj，大括号里面的是累计，包括之前的expr
            }
            //constraints
            for(i = 0 ; i < realistic_trip_num ; i++)//对每一行    这部分的内容是aij*xj>=n
            {
                INumExpr expr = masterModel.NumExpr();

                for(j = 0 ; j < initialPath_num ; j++)//对每一列
                {
                    expr = masterModel.Sum(expr ,
                                           masterModel.Prod(A_Matrix[j][i] , DvarSet[j]));//在从初始解传值给A_Matrix，已经针对网络复制作了处理
                }//小括号路里aij*xj

                Constraint[i] = masterModel.AddGe(expr ,NUMBER_CREW );//约束list addge表示返回一个大于等于n的数
            }

            for (j = 0; j < initialPath_num; j++)//对每一列       
            {
                INumExpr expr = masterModel.NumExpr();
                expr = masterModel.Sum(expr, DvarSet[j]);//在从初始解传值给A_Matrix，已经针对网络复制作了处理
            }
            
            
            //这里怎样使约束expr的值等于1？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？
        }

        public void Build_RMP_YY(InitialSolution IS)//主问题的建模
        {
            initialPath_num = IS.PathSet.Count;
            trip_num = TripList.Count;
            realistic_trip_num = NetWork.num_Physical_trip;

            A_Matrix = IS.A_Matrix;
            DvarSet = new List<INumVar>();//x
            CoefSet = new List<double>();//cij            
            ObjCoefSet = new List<double>();
            PathSet = new List<Pairing>();//列池
           
            CoefSet = IS.Coefs;//IS初始解
            PathSet = IS.PathSet;

            ObjCoefSet = IS.ObjCoefs;
           
            foreach (var p in PathSet)
            {
                ColumnPool.Add(p);
            }
            
            masterModel = new Cplex();
            Obj = masterModel.AddMinimize();
            //Constraint = new IRange[realistic_trip_num];
            Ct_cover = new IRange[NUMBER_CREW];
            Ct_crewNum = new IRange[5][]; //默认每条交路为5天
            ct_nb = new List<IRange>();

            /**按行建模**/
            //vars and obj function
            int i, j;
            for (j = 0; j < initialPath_num; j++)//定义决策变量和目标函数
            {
                INumVar dvar = masterModel.NumVar(0, 1, NumVarType.Float);//INumVar-cplex里面的，定义决策变量。后面括号中的意思是定义var是0-1之间的浮点值
                dvar.Name = "crew_" + PathSet[j].Arcs.First().D_Point.CrewID + "_" + j;

                DvarSet.Add(dvar);
                Obj.Expr = masterModel.Sum(Obj.Expr, masterModel.Prod(CoefSet[j], DvarSet[j]));//后面的小括号里面是一个cij*xj，大括号里面的是累计，包括之前的expr
            }

            //constraints            
            for (i = 0; i < 5; i++)//对每一天
            {
                INumExpr expr = masterModel.NumExpr();
                Dictionary<int, List<int>> route_paths_map = new Dictionary<int, List<int>>();
                for (j = 0; j < initialPath_num; j++) //对每天的工作链分类
                {
                    if (A_Matrix[j][i] == 0) {
                        continue;
                    }
                    if (!route_paths_map.ContainsKey(A_Matrix[j][i])) {
                        route_paths_map.Add(A_Matrix[j][i], new List<int>());
                    }
                    route_paths_map[A_Matrix[j][i]].Add(j);   
                }

                Ct_crewNum[i] = new IRange[route_paths_map.Count];
                foreach (var routePathsPair in route_paths_map) { //对第i天的每条交路
                    foreach (var xj in routePathsPair.Value)
                    {
                        expr = masterModel.Sum(expr, DvarSet[xj]);
                    }

                    Ct_crewNum[i][routePathsPair.Key-1] = masterModel.AddGe(expr, 1); //20191004 一条交路1个人 TODO
                    string name = "day_" + i + "_route_" + routePathsPair.Key;
                    Ct_crewNum[i][routePathsPair.Key-1].Name = name;

                    ct_nb.Add(Ct_crewNum[i][routePathsPair.Key - 1]);
                }                
            } 
            // 每个乘务员只能有一条工作链
            Dictionary<int, List<int>> crewID_paths_map = new Dictionary<int, List<int>>();
            for (j=0; j<initialPath_num;j++) {
                Pairing path = PathSet[j];
                int crew_id = path.Arcs.First().D_Point.CrewID;
                if (!crewID_paths_map.ContainsKey(crew_id)) { //Arcs.First.D是身份节点
                    crewID_paths_map.Add(crew_id, new List<int>());
                }
                crewID_paths_map[crew_id].Add(j);
            }
            if (crewID_paths_map.Count != NUMBER_CREW) {
                throw new System.Exception("乘务员数量有误");               
            }

            foreach (var crewID_paths_pair in crewID_paths_map) {
                INumExpr expr = masterModel.NumExpr();
                foreach (var xj in crewID_paths_pair.Value) {
                    expr = masterModel.Sum(expr, DvarSet[xj]);
                }
                Ct_cover[crewID_paths_pair.Key - 1] = masterModel.AddEq(expr, 1);
            }
            
        }

        public void WriteModelToFIle(/*string modelFile*/) {
            string modelFile = "model.lp";
            masterModel.ExportModel(modelFile);
        }


        #region 分支定界
        //分支定界部分的内容最后再看
        /// <summary>嵌入列生成的分支定界
        /// 中间会保存产生的可行解们到指定文件
        /// </summary>
        /// <param name="root_node"></param>
        /// <param name="LB"></param>
        /// <param name="UB"></param>
        public void Branch_and_Bound(TreeNode root_node , double LB , double UB)
        {
            string path = System.Environment.CurrentDirectory + "\\结果\\JJ158_SolutionPool.txt";

            //TODO:中间可行解存放文件，传参
            StreamWriter fesible_solutions = new StreamWriter(path);
            Report repo = new Report();
            int num_iter = 0;
            bool flag = false;
            int break_after_findFeasible = 10;
            while(true)
            {
                #region //先判断可行，再比较目标函数大小
                /*
                if (Feasible(root_node) == false)
                {
                    if (root_node.obj_value > UB) //不必在该点继续分支
                    {
                        Backtrack(ref root_node.fixed_vars);                                              
                    }
                    else //root_node.obj_value <= UB,有希望，更新下界，继续分支,
                    {
                        LB = root_node.obj_value;                        
                    }   
                }
                else //可行，更新上界。【2-24-2019：只要可行，不管可行解是否优于当前最优可行（OBJ < UB）都不用在该点继续分支，而是回溯】
                {                    
                    if (root_node.obj_value <= UB) //root_node.obj_value <= UB，更新UB，停止在该点分支，回溯
                    {
                        UB = root_node.obj_value;
                        RecordFeasibleSolution(root_node, ref best_feasible_solution);

                        if ((UB - LB) / UB < GAP) //这也是停止准则，但只能放在这里
                        {                            
                            break;
                        }
                    }

                    Backtrack(ref root_node.fixed_vars); 
                }

                SolveChildNode(ref root_node);
                */
                #endregion
                Console.WriteLine("第{0}个结点，OBJ为{1}" , num_iter + 1 , root_node.obj_value);

                #region 先比较界限，再判断是否可行
                if(root_node.obj_value > UB) //不论可行与否，只要大于上界，都必须剪枝，然后回溯
                {
                    Backtrack(ref root_node);
                }
                else if(LB <= root_node.obj_value && root_node.obj_value <= UB)
                {
                    if(Feasible(root_node) == false) //不可行，更新下界；继续向下分支
                    {
                        LB = root_node.obj_value;
                    }
                    else //可行，更新上界，记录当前可行解；回溯
                    {
                        Console.WriteLine("可行节点");
                        UB = root_node.obj_value;
                        flag = true;
                        //RecordFeasibleSolution(root_node, ref best_feasible_solution);
                        RecordFeasibleSolution(ref best_feasible_solution);
                        #region
                        fesible_solutions.WriteLine("第{0}个节点" , num_iter);
                        fesible_solutions.WriteLine("UB = {0}, LB = {1}, GAP = {2}" , UB , LB , (UB - LB) / UB);
                        int num = 0;
                        foreach(var index in root_node.fixing_vars)
                        {
                            fesible_solutions.WriteLine("乘务交路 " + (num++) + " ");
                            StringBuilder singlepath = new StringBuilder();
                            repo.summary_single.SetValue(0 , 0 , 0 , 0);
                            //foreach (var arc in ColumnPool[index].Arcs)
                            //{
                            //    fesible_solutions.Write(arc.D_Point.TrainCode + "->");

                            //}
                            fesible_solutions.Write(repo.translate_single_pairing(ColumnPool[index] ,
                                                    ref singlepath , ref repo.summary_single));
                            fesible_solutions.WriteLine();
                        }
                        foreach(var k_v in root_node.not_fixed_var_value_pairs)
                        {
                            if(k_v.Value > 0)
                            {
                                fesible_solutions.WriteLine("乘务交路 " + (num++) + " ");
                                StringBuilder singlepath = new StringBuilder();
                                repo.summary_single.SetValue(0 , 0 , 0 , 0);
                                //foreach (var arc in ColumnPool[k_v.Key].Arcs)
                                //{
                                //    fesible_solutions.Write(arc.D_Point.TrainCode + "->");
                                //}
                                fesible_solutions.Write(repo.translate_single_pairing(ColumnPool[k_v.Key] ,
                                                        ref singlepath , ref repo.summary_single));
                                fesible_solutions.WriteLine();                              

                            }
                        }
                        #endregion

                        
                        Backtrack(ref root_node);
                    }
                }
                else if(root_node.obj_value < LB) //TODO：这种情况不知道是否会出现
                {
                    LB = root_node.obj_value;
                }

                Branch(ref root_node); //寻找需要分支的变量

                if(flag) {
                    if(break_after_findFeasible-- == 0)
                    {
                        break;
                    }
                }
                if(TerminationCondition(root_node , UB , LB) == true)
                {
                    fesible_solutions.Close();
                    break;
                }
                num_iter++;

                CG(ref root_node); //求解子节点
                #endregion
            }

        }

        /// <summary>停止准则
        /// 1.达到设定的GAP 2.所有变量均已分支过
        /// 还可以添加其他的
        /// </summary>
        /// <param name="tree_node"></param>
        /// <param name="UB"></param>
        /// <param name="LB"></param>
        /// <returns></returns>
        bool TerminationCondition(TreeNode tree_node , double UB , double LB)
        {
            return MetGAP(UB , LB) || NoVarBranchable(tree_node);
        }
        bool NoVarBranchable(TreeNode node)
        {
            /*没有节点（变量）可以回溯，所有变量分支过了
                           * 没有变量可以分支，所有变量都分支过了
                            */
            if(root_node.fixing_vars.Count == 0
                || root_node.not_fixed_var_value_pairs.Count == 0)
            {
                Console.WriteLine("找不到可分支的变量");
                return true;
            }
            return false;
        }
        bool MetGAP(double UB , double LB)
        {
            return (UB - LB) < UB * GAP;
        }

        /// <summary>判断是否是可行解
        ///每个变量均为整数{0,1}
        /// </summary>
        /// <param name="tree_node"></param>
        /// <returns></returns>
        bool Feasible(TreeNode tree_node)
        {
            foreach(var var_value in tree_node.not_fixed_var_value_pairs)
            {
                if(ISInteger(var_value.Value) == false)
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>判断"value"是否为整数
        /// 为了普遍性.（本问题决策变量是0-1变量）
        /// </summary>
        /// <param name="value"></param>
        /// <param name="epsilon"></param>
        /// <returns></returns>
        bool ISInteger(double value , double epsilon = 1e-10)//是否是整数   epsilon-一个数学符号
        {
            return Math.Abs(value - Convert.ToInt32(value)) <= epsilon; //不是整数，不可行（浮点型不用 == ，!=比较）           
        }

        /// <summary>回溯 + 剪枝
        /// 已分支过的变量不得再分支
        /// </summary>
        /// <param name="tree_node"></param>
        void Backtrack(ref TreeNode tree_node)
        {
            //剪枝
            tree_node.fixed_vars.Add(tree_node.fixing_vars.Last());

            tree_node.fixing_vars.RemoveAt(tree_node.fixing_vars.Count - 1);
        }
        /// <summary>选择分支变量
        /// value最大（最接近1）的变量（Index）
        /// </summary>
        /// <param name="tree_node"></param>
        void Branch(ref TreeNode tree_node)
        {
            //找字典最大Value对应的key
            /*用lambda： var k = node.not_fixed_var_value_pairs.FirstOrDefault(v => v.Value.Equals
                                                                            *(node.not_fixed_var_value_pairs.Values.Max()));*/

            int var_of_max_value = tree_node.not_fixed_var_value_pairs.First().Key;
            double max_value = tree_node.not_fixed_var_value_pairs.First().Value;

            foreach(var var_value in tree_node.not_fixed_var_value_pairs)
            {
                var_of_max_value = max_value > var_value.Value ? var_of_max_value : var_value.Key;
                max_value = max_value > var_value.Value ? max_value : var_value.Value;
            }

            tree_node.fixing_vars.Add(var_of_max_value);
            tree_node.not_fixed_var_value_pairs.Remove(var_of_max_value);
        }

        /// <summary>记录当前最优解
        /// value = 1 的dvar
        /// </summary>
        /// <param name="best_feasible_solution"></param>
        void RecordFeasibleSolution(ref List<int> best_feasible_solution)//记录可行解
        {
            best_feasible_solution.Clear();
            double value;
            for(int i = 0 ; i < DvarSet.Count ; i++)
            {
                value = masterModel.GetValue(DvarSet[i]);
                //判断其变量是否为 1（为不失一般性，写的函数功能是判断是否为整数）
                if(Convert.ToInt32(value) > 0 && ISInteger(value))
                {
                    best_feasible_solution.Add(i);
                }
            }
        }

        //void RecordFeasibleSolution(TreeNode node, ref List<int> best_feasible_solution)
        //{
        //    best_feasible_solution.Clear(); //找到更好的可行解了，不需要之前的了            
        //    ///方式2
        //    //已分支的变量固定为 1，直接添加
        //    foreach (var v in node.fixing_vars) 
        //    {
        //        best_feasible_solution.Add(v);
        //    }

        //    //TODO:回溯剪枝掉的var也得判断其值

        //    //未分支的变量，判断其是否为 1（为不失一般性，写的函数功能是判断是否为整数）
        //    foreach (var var_value in node.not_fixed_var_value_pairs) 
        //    {
        //        if (Convert.ToInt32(var_value.Value) > 0 && ISInteger(var_value.Value)) 
        //        {
        //            best_feasible_solution.Add(var_value.Key);
        //        }
        //    }
        //}

        #endregion//

        #region 列生成

        /// <summary>在树节点"tree_node"章进行列生成
        /// 求得当前树节点的最优目标值
        /// </summary>
        /// <param name="tree_node"></param>
        public void CG(ref TreeNode tree_node)
        {
            //固定分支变量的值（==1）等于是另外加上变量的取值范围约束
            FixVars(tree_node.fixing_vars);
            double cur_reducedCost = 0;
            //迭代生成列
            for(;;)
            {
                this.OBJVALUE = SolveRMP();
                //求解子问题，判断 检验数 < -1e-8 ?

                if(IsLPOpt(cur_reducedCost))
                {
                    break;
                }
                Console.WriteLine("检验数 = {0}" , R_C_SPP.Reduced_Cost);
                cur_reducedCost = R_C_SPP.Reduced_Cost;
                double col_coef = 0;
                int[] aj;
                //ColumnPool = DeleteColumn(ColumnPool);
                foreach(Pairing column in R_C_SPP.New_Columns)
                {
                    ColumnPool.Add(column);

                    col_coef = column.ObjCoef;
                    aj = column.CoverMatrix;

                    INumVar column_var = masterModel.NumVar(0 , 1 , NumVarType.Float);//每加一列都要对模型进行修改，因为决策变量多了
                    // function
                    Obj.Expr = masterModel.Sum(Obj.Expr , masterModel.Prod(col_coef , column_var));
                    // constrains
                    for(int i = 0 ; i < realistic_trip_num ; i++)
                    {
                        Constraint[i].Expr = masterModel.Sum(Constraint[i].Expr ,
                                                            masterModel.Prod(aj[i] , column_var));
                    } //TODO 20191006

                    DvarSet.Add(column_var);
                    A_Matrix.Add(aj);
                    ObjCoefSet.Add(col_coef);
                }
            }

            //传递信息给tree_node
            tree_node.obj_value = this.OBJVALUE;

            tree_node.not_fixed_var_value_pairs.Clear();
            for(int i = 0 ; i < DvarSet.Count ; i++)
            {
                //将未分支的变量添加到待分支变量集合中
                //!被回溯“扔掉”的变量不能再添加到fixed_vars中,须加上 && tree_node.fixed_vars.Contains(i) == false
                if(tree_node.fixing_vars.Contains(i) == false && tree_node.fixed_vars.Contains(i) == false)
                {
                    tree_node.not_fixed_var_value_pairs.Add(i , masterModel.GetValue(DvarSet[i]));
                }
            }

        }

        public List<Pairing> DeleteColumn(List<Pairing> column)
        {
            List<Pairing> newcolumn = new List<Pairing>();
            double temp;
            foreach(Pairing p in column)
            {
                newcolumn.Add(p);
            }
            if(newcolumn.Count > 100)
            {
                for(int j = 0 ; j < newcolumn.Count - 1 ; j++)
                {
                    for(int i = 0 ; i < newcolumn.Count - 1 - j ; i++)
                    {
                        if(newcolumn[i].accumuwork < newcolumn[i + 1].accumuwork)
                        {
                            temp = newcolumn[i].accumuwork;
                            newcolumn[i].accumuwork = newcolumn[i + 1].accumuwork;
                            newcolumn[i + 1].accumuwork = temp;
                        }
                    }
                }
                for(int i = 0 ; i < column.Count - 100 ; i++)
                {
                    newcolumn.Remove(newcolumn[i]);
                }
            }
            return newcolumn;
        }
        void FixVars(List<int> fixeing_vars)
        {
            foreach(int i in fixeing_vars)
            {
                DvarSet[i].LB = 1.0;
                DvarSet[i].UB = 1.0;
            }
        }
        /// <summary>返回当前RMP的目标函数值
        /// try catch:CPLEX求解linear relaxation 失败
        /// </summary>
        /// <returns></returns>
        public double SolveRMP()
        {
            try
            {
                masterModel.Solve();
            }
            catch(ILOG.Concert.Exception ex)
            {
                Console.WriteLine("Current RMP can't solved, there might exit some error");
                Console.WriteLine("{0} from {1}" , ex.Message , ex.Source);
            }

            return masterModel.GetObjValue();
        }

        bool IsLPOpt(double last_reducedCost)//判断检验数是否满足要求
        {
            //Change_Arc_Length();
            Change_Arc_Length_YY();

            this.R_C_SPP.ChooseCostDefinition(1);
            this.R_C_SPP.ShortestPath("Forward");
            //FindMultipleNewPColumn():True-找到新列，继续迭代;False-找不到新列，最优,停止
            this.R_C_SPP.FindMultipleNewPColumn(num_AddColumn);

            return R_C_SPP.Reduced_Cost == last_reducedCost || R_C_SPP.Reduced_Cost > -10;
        }
        void Change_Arc_Length()
        {
            int i, j;
            double price = 0;
            for(i = 0 ; i < realistic_trip_num ; i++)
            {
                price = masterModel.GetDual(Constraint[i]);
                //Console.Write("dual price {0}: {1}\t", i + 1, price);
                for(j = 0 ; j < trip_num ; j++)
                {
                    if(TripList[j].ID == i + 1)
                    {
                        // constraint对应的dual 与tripList的不对应，由于删去了某些点，不能以Index来查找点ID
                        //triplist Nodeset几个引用间的关系也不明确，牵涉到拓扑、最短路、原始网络
                        TripList[j].Price = price;
                    }
                }
            }
        }

        void Change_Arc_Length_YY()
        {
            double[] priceOfCrew = new double[NUMBER_CREW];            
            priceOfCrew = masterModel.GetDuals(Ct_cover); 
            //crew对应的对偶价格，等于是固定成本，
            //只要是该crew的工作链，都需要加上改价格，所以将改价格赋值给身份节点
            for (int i = 0; i < NUMBER_CREW; i++)
            {
                TripList[i * 6].Price = priceOfCrew[i];
            }
            
            // ct of crew number
            double[][] priceOfCtCrewNum = getDualsOfCtCrewNum();
            Dictionary<int, List<int>> routeID_tripIDs_map = Network.RouteID_TripIDs_Map;
            Dictionary<int, List<int>> day_tripIDs_map = Network.Day_TripIDs_Map;
            //day_tripid 和 routeid_tripid 取交集，得到第i天的交路集合            
            for (int i = 0; i < priceOfCtCrewNum.Length; i++) {                
                for (int j = 0; j < priceOfCtCrewNum[i].Length; j++) { //第i天包含的交路集合
                    List<int> tripsOfCurRoute = day_tripIDs_map[i].Intersect(routeID_tripIDs_map[j+1]).ToList();
                    //第i天第j条routing的所有crew节点，共享更新price，即price是该routing的，均分给其上的crew
                    int n = tripsOfCurRoute.Count;
                    foreach (var id in tripsOfCurRoute) {
                        TripList[id].Price = priceOfCtCrewNum[i][j] / n;
                    }
                }
            }
        }

        double[][] getDualsOfCtCrewNum() {
            double[][] price = new double[5][]; //行：day 列：route_id
            for (int i = 0; i < 5; i++) {             
                for (int j = 0; j < Ct_crewNum[i].Length; j++)
                {
                    price[i] = masterModel.GetDuals(Ct_crewNum[i]);
                }
            }

            return price;
        }
        #endregion
    }

}
