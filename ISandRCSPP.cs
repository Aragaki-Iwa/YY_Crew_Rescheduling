using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace CG_CSP_1440
{
    class InitialSolution//初始解
    {
        //输出,传的应该是 out来传
        public List<int[]> A_Matrix;//主问题Aij矩阵
        public List<double> Coefs;
        public List<double> AccumuWorkSet;
        public List<double> ObjCoefs;

        
        public List<Pairing> PathSet;

        public double initial_ObjValue;
        
        
        //输入变量
        NetWork Net = new NetWork();
        List<Node> NodeSet;
        List<Node> DNodeList;
        //List<Node> TripList;//目标点集。依次以tripList中的点为起点，求其顺逆向寻最短路
        List<Node> LineList;//将linelist改成lineidlist
                                 //
        List<int> LineIDList;
       
       

        public InitialSolution(NetWork Network) //这是一个两天的网，需要除以maxday来还原成一天的网
        {
            Net = Network;
            NodeSet = Net.NodeSet;
            DNodeList = Net.DNodeList;
            LineList = new List<Node>();//没用
            LineIDList = new List<int>();//车次，所有的运行线，也就是编号
                                         //            试着与WorkIDList对应一下，感觉应该是对应于我的点的下面的ID一类
            PathSet = new List<Pairing>();
            //TripList = Net.TripList;            
            for (int i = 0; i < Net.TripList.Count && LineIDList.Count != NetWork.num_Physical_trip; i++)
            {
                //LineList.Add(Net.TripList[i]);                
                if (LineIDList.Contains(Net.TripList[i].ID) == false)
                    //如果lineid集合没有包含trip集合里的某个元素，那就把它加入lineid集合
                {
                    LineIDList.Add(Net.TripList[i].ID);
                }

                if (LineList.Contains(Net.TripList[i]) == false)
                {
                    LineList.Add(Net.TripList[i]);
                }
            }
            #region
            //因为我的网不是几天的，所以不需要除以maxday

            //for (int i = 0; i < Net.TripList.Count / NodeSet[i].LengthofRoute; i++) 
            //{
            //    if (LineList.Contains(Net.TripList[i]) == false)
            //    {
            //        LineList.Add(Net.TripList[i]);                
            //    }
            //}
            #endregion

        }

        public List<Pairing> GetFeasibleSolutionByMethod1()//最短路的求解方法，任意选择一种，包括下面的pently
        {         
            //中间变量，用来传值
            Node trip = new Node();
            Pairing loopPath;//等同于pairing
                                                               
            int i, j;                        
            //Node s = NodeSet[0];
            Topological2 topo;
            RCSPP R_C_SPP = new RCSPP(Net, out topo);           
            //R_C_SPP.UnProcessed = new List<Node>();
            //for (i = 0; i < Topo.Order.Count; i++) {
            //    R_C_SPP.UnProcessed.Add(Topo.Order[i]);
            //}
            R_C_SPP.ShortestPath("Forward");
                                                                       //backword后向标号；forward前向标号
            
            //R_C_SPP.UnProcessed = Topo.Order; //TODO:测试 2-24-2019
            R_C_SPP.ShortestPath("Backward");
            //for (i = 0; i < NodeSet.Count; i++) 
            //{
            //    trip = NodeSet[i];
            //    trip.Visited = false;
            //    if (trip.ID != 0 && trip.ID != -1) {
            //        TripList.Add(trip);
            //    }
            //}
            //也按拓扑顺序否？？

            for (i = 0; i < LineList.Count; i++) {
                if (LineList[i].TypeofLeave == 0) {
                    LineList.RemoveAt(i);
                    i--;
                }
            }
            while (LineList.Count > 0) 
            //while (LineIDList.Count > 0)
            {
                trip = LineList[0];//这里以 1,2,3...顺序寻路，使得许多路的大部分内容相同，可不可以改进策略                
                loopPath = FindFeasiblePairings(trip);
                LineList.RemoveAt(0);
                if (loopPath == null)
                {
                    throw new Exception("找不到可行回路！");

                }
                else
                {
                    PathSet.Add(loopPath);
                    for (i = 0; i < loopPath.Arcs.Count; i++)
                    {
                        trip = loopPath.Arcs[i].D_Point;
                        for (j = 0; j < LineList.Count; j++)
                        {
                            if (LineList[j].ID == trip.ID)
                            {
                                //trip.Visited = true;
                                LineList.RemoveAt(j);
                                break;
                            }
                        }
                    }
                }
            }

            //PrepareInputForRMP(Net.TripList);
            PrepareInputForRMP_YY(); //20191004

            return this.PathSet;
        }
        Pairing FindFeasiblePairings(Node trip)//寻找合适的交路，计算累加量
        {
            Pairing loopPath = new Pairing();//output
            loopPath.Arcs = new List<Arc>();
            int i,j;
            int minF = 0, minB = 0;//forward backword
            Label labelF, labelB;
            Arc arc;            

            Double AccumuWorkday, T3, C;
            double MAX = 666666;
            Double Coef = MAX;
            for (i = 0; i < trip.LabelsForward.Count; i++) 
            {
                labelF = trip.LabelsForward[i];                
                for (j = 0; j < trip.LabelsBackward.Count; j++) 
                {
                    labelB = trip.LabelsBackward[j];
                    if(labelF.BaseOfCurrentPath.Station != labelB.BaseOfCurrentPath.Station)//？？？？？？？？？？？？？？？？？？？？？？？？
                                                                            //？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？
                    {
                        continue;
                    }
                    AccumuWorkday = labelF.AccumuWorkday + labelB.AccumuWorkday - trip.TypeofWorkorRest;
                    if(trip.TypeofWorkorRest==1)//首先判断这一天的作休类型
                    {
                        T3 = labelF.AccumuWork + labelB.AccumuWork - trip.Length;//总乘务时间
                    }
                    else
                    {
                        T3 = labelF.AccumuWork + labelB.AccumuWork;//工作时间
                    }
                    C = labelF.AccumuCost + labelB.AccumuCost ;//C-cost；貌似不用加length？？？？？？？？？？？？？？？？？？？？


                    //求初始解时，Cost即为非乘务时间，即目标函数，而在列生成迭代中，非也（因为对偶乘子）                  
                    if (//AccumuWorkday   <= trip.NumberofWorkday &&//T3   <= CrewRules.TotalCrewTime&&
                        Coef >= C) //find minmal cost
                    {
                        minF = i;
                        minB = j;
                        Coef = C;
                        
                    }
                }
            }
            if (Coef < MAX) //Coef-cj
                //                                       这部分还有待修改
            {
                labelF = trip.LabelsForward[minF];
                labelB = trip.LabelsBackward[minB];
                loopPath.Coef = 0;//1440;
                int pathday = 1;
                loopPath.accumuwork = labelF.AccumuWork + labelB.AccumuWork;
                loopPath.ObjCoef = Net.GetObjCoef(loopPath.accumuwork , loopPath.Coef);
                arc = labelF.PreEdge;
                while (arc.O_Point.ID != 0)
                {
                    //pathday = arc.ArcType == 22 ? pathday + 1 : pathday;
                    loopPath.Coef += arc.Cost;

                    loopPath.Arcs.Insert(0, arc);
                    labelF = labelF.PreLabel;
                    arc = labelF.PreEdge;
                }
                loopPath.Arcs.Insert(0, arc);

                arc = labelB.PreEdge;
                while (arc.D_Point.ID != -1)
                {
                    //pathday = arc.ArcType == 22 ? pathday + 1 : pathday;
                    loopPath.Coef += arc.Cost;

                    loopPath.Arcs.Add(arc);
                    labelB = labelB.PreLabel;
                    arc = labelB.PreEdge;
                }
                loopPath.Arcs.Add(arc);

                //loopPath.Coef *= pathday;
            }
            if (loopPath.Arcs.Count == 0)
            {                                  
                loopPath = default(Pairing);
            } 
            return loopPath; 
        }

        //public list<pairing> getfeasiblesolutionbypenalty() //penalty-标号法的罚数
        //{
        //    node trip = new node();
        //    pairing pairing;
        //    int i;

        //    topological2 topo;

        //    rcspp r_c_spp = new rcspp(net, out topo); //todo:测试 2-24-2019
        //    r_c_spp.unprocessed = new list<node>();
        //    for (i = 0; i < topo.order.count; i++)
        //    {
        //        r_c_spp.unprocessed.add(topo.order[i]);
        //    }
        //    int m = 99999;
        //    r_c_spp.choosecostdefinition(0);
        //    arc arc;
        //    迭代，直到所有trip被cover


        //    while (linelist.count > 0)
        //        while (lineidlist.count > 0)
        //        {
        //            console.write(lineidlist.count + ", ");

        //            r_c_spp.shortestpath("forward");
        //            r_c_spp.findnewpath();

        //            pairing = r_c_spp.new_column;
        //            todo: 若当前找到的路包含的点均已被pathset里的路所包含，就是说该条路没有囊括新的点，那就不添加到pathset中
        //            pathset.add(pairing);
        //            for (i = 1; i < pairing.arcs.count - 2; i++) //起终点不用算
        //            {
        //                arc = pairing.arcs[i];
        //                需还原pairing的cost，减去 当前 增加的 m 的部分，即price
        //                if (arc.d_point.numvisited > 0)
        //                {
        //                    pairing.cost += arc.d_point.price;
        //                }

        //                arc.d_point.numvisited++;
        //                arc.d_point.price = -arc.d_point.numvisited * m;
        //                第二天对应的复制点也要改变
        //                if (crewrules.maxdays > 1)//&& arc.d_point.starttime < 1440) 
        //                {
        //                    for (int j = 0; j < nodeset.count; j++)
        //                    {
        //                        if (nodeset[j].lineid == arc.d_point.lineid && nodeset[j].starttime > arc.d_point.starttime)
        //                        {
        //                            nodeset[j].numvisited++;
        //                            nodeset[j].price = -nodeset[j].numvisited * m;
        //                        }
        //                    }
        //                }

        //                linelist.remove(arc.d_point);
        //                lineidlist.remove(arc.d_point.lineid);
        //            }
        //        }
        //    还原trip的price
        //    foreach (var node in this.nodeset)
        //    {
        //        node.numvisited = 0;
        //        node.price = 0;
        //    }

        //    prepareinputforrmp(net.triplist);

        //    return this.pathset;
        //}

        private void PrepareInputForRMP(List<Node> TripList) //2-21-2019改前是 ref
            //准备主问题的输入
        {
            //Get Coef in FindAllPaths
            Coefs = new List<double>();
            AccumuWorkSet = new List<double>();
            ObjCoefs = new List<double>();
            A_Matrix = new List<int[]>();
            int realistic_trip_num = NetWork.num_Physical_trip;
            foreach (var path in PathSet) {
                //Coefs.Add(path.Cost);
                Coefs.Add(path.Coef);
                AccumuWorkSet.Add(path.accumuwork);
                ObjCoefs.Add(Net.GetObjCoef(path.accumuwork , path.Coef));

                int[] a = new int[realistic_trip_num];
                for (int i = 0; i < realistic_trip_num; i++) {
                    a[i] = 0;
                }

                foreach (Node trip in TripList) {
                    foreach (Arc arc in path.Arcs) {
                        if (arc.D_Point == trip)
                        {                            
                            //a[trip.LineID - 1] = 1;
                            a[trip.ID - 1] = 1;
                            //如果一条边的终点等于trip，那么这个trip的上一个trip的车次的矩阵系数就是1？？？？？？？？？？？
                            //aij用来表示第i天的点是否出现在第j个乘务人员的工作链中
                            //这里考虑直接用node下面的ID来代替LineID
                        }
                    }
                }

                A_Matrix.Add(a);
            }

            GetObjValue();
        }

        /// <summary>
        /// 初始化A_Matrix和Coefs
        /// A_Matrix[j][i]表示工作链j第i天值乘哪一条交路，若第i天休息，则赋值为0 //TODO:20191006这里或许有问题，涉及到替班
        /// </summary>       
        private void PrepareInputForRMP_YY(/*List<Node> TripList*/) {
            //Get Coef in FindAllPaths
            Coefs = new List<double>();            
            A_Matrix = new List<int[]>();
            //ObjCoefs = new List<double>();
            int nb_of_day = 5;
            foreach (var path in PathSet)
            {              
                Coefs.Add(path.Coef);
             
                int[] a = new int[nb_of_day];
                for (int i = 0; i < nb_of_day; i++)
                {
                    a[i] = 0;
                }
                
                var path_arcs = path.Arcs;
                for (int cur_day = 1; cur_day <= path_arcs.Count-2; cur_day++) {
                    Node cur_node = path_arcs[cur_day].D_Point;
                    if (cur_node.TypeofWorkorRest == 1) {
                        a[cur_day - 1] = cur_node.RoutingID;
                    }                    
                }                
                A_Matrix.Add(a);
            }

            GetObjValue();
        }

        private double GetObjValue() 
        {
            //foreach (var c in ObjCoefs) 
            //{
            //    initial_ObjValue += c;
            //}
            foreach (var c in Coefs)
            {
                initial_ObjValue += c;
            }
            return initial_ObjValue;
        }

    }
    
    //资源约束最短路
    class RCSPP             //求最短路的类
    {                
        //OUTPUT
        public double Reduced_Cost = 0;
        public  Pairing New_Column;
        //public int[] newAji;
        //public int[,] newMultiAji;

        //添加的

        public List<Pairing> New_Columns;
        List<Label> negetiveLabels;
        //public double[] reduced_costs;

        //与外界相关联的
        NetWork Net = new NetWork();
        public List<Node> UnProcessed = new List<Node>();
                                                   //Topo序列。      有向无环图才有topo序列
        
        public List<CrewBase> CrewbaseList = DataReader.CrewBaseList; //2-20-2019

        double accumuConsecDrive, accumuDrive, accumuWork, C;//资源向量,cost
        double accumuCost, accumuWorkday, accumuRestday;
        bool resource_feasible;
        string direction;

        //public Dictionary<string, int> costDefinition = new Dictionary<string, int>();
        int costType;

        public RCSPP(NetWork net, out Topological2 topological) 
        {
            Net = net;
            Node s = net.NodeSet[0];
            topological = new Topological2(net, s);

            foreach (Node node in topological.Order) 
            {
                UnProcessed.Add(node);
            }
        }

        /// <summary>
        ///  definetype in [0,2],选择成本的具体定义。//（此前可定义一个字典，选择定义）
        /// </summary>
        /// <param name="defineType"></param>
        public void ChooseCostDefinition(int defineType)//见setcostdefinition方法
        {
            try
            {
                if (0 <= defineType && defineType <= 2)
                {
                    this.costType = defineType;
                }
                else
                {
                    throw new System.Exception("参数输入错误, defineType must in [0, 2]");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ShortestPath(string Direction) //Forward;Backward
        {
            direction = Direction;
            Node trip1, trip2;            
            Label label1, label2;
            int i, j;
            
            InitializeStartNode();
            //framework of labeling setting algorithm                                                
            if (direction == "Forward")
            {
                for (int t = 0; t < UnProcessed.Count; t++)//unprocessed-未被加工的
                {
                    trip1 = UnProcessed[t];
                    //2-20-2019                       
                    if (trip1.DayofRoute == -1)//0) //CHANGED 20190920 没有基地点了，只有虚拟起终点
                    //if (trip1.Type == 0)//基地起点
                    {
                        InitializeBaseNode(trip1, trip1.LabelsForward);
                    }
                    //end
                    //dominated rule
                    //这里可以再想想优化,实际上类似于排序，采用类似于归并排序的处理,本质是分治思想
                    #region  未优化的，直接两两比较，复杂度 O(n^2)(实际共比较n(n-1)/2次)
                    //for (int l1 = 0; l1 < trip1.LabelsForward.Count; l1++)
                    //{
                    //    for (int l2 = l1 + 1; l2 < trip1.LabelsForward.Count; l2++)
                    //    {
                    //        DominateRule(trip1.LabelsForward[l1], trip1.LabelsForward[l2]);
                    //    }
                    //}
                    //for (i = 0; i < trip1.LabelsForward.Count; i++)
                    //{
                    //    if (trip1.LabelsForward[i].Dominated == true)
                    //    {
                    //        trip1.LabelsForward.RemoveAt(i);
                    //        i--;
                    //    }
                    //}
                    #endregion
                    //优化后，速度提高了10多倍
                    RemainPateroLabels(ref trip1.LabelsForward);

                    //判断是否可延伸，即是否 resource-feasible
                    for (i = 0; i < trip1.Out_Edges.Count; i++)
                    {
                        Arc arc = trip1.Out_Edges[i];
                        trip2 = arc.D_Point;
                        
                        
                        for (j = 0; j < trip1.LabelsForward.Count; j++)
                        {                            
                            label1 = trip1.LabelsForward[j];

                            resource_feasible = false;                           
                            label2 = REF(label1, trip2, arc);
                            
                            if (resource_feasible)//label1可延伸至trip2
                            {
                                
                                trip2.LabelsForward.Add(label2);
                            }
                            else { label2 = default(Label); }
                        }
                    }
                }
            }
            else if (direction == "Backward")
            {
                foreach (var dNode in Net.DNodeList)
                {                    
                    InitializeBaseNode(dNode, dNode.LabelsBackward);                    
                }

                while (UnProcessed.Count > 0)
                {
                    trip1 = UnProcessed[0];
                    
                    UnProcessed.Remove(trip1);
                    //dominated rule
                    RemainPateroLabels(ref trip1.LabelsBackward);
                    //判断是否可延伸，即是否 resource-feasible
                    for (i = 0; i < trip1.In_Edges.Count; i++)
                    {
                        Arc arc = trip1.In_Edges[i];
                        trip2 = arc.O_Point;

                        if (trip2.CrewID == trip2.CrewID && (trip2.TypeofLeave == 0 || trip1.TypeofLeave == 0)) 
                        {
                            //若属于一个人，且其中一个点为请假，则不可延伸
                            continue;                        
                        }

                        for (j = 0; j < trip1.LabelsBackward.Count; j++)
                        {                            
                            label1 = trip1.LabelsBackward[j];

                            resource_feasible = false;
                            label2 = REF(label1, trip2, arc);
                            if (resource_feasible)//label1可延伸至trip2
                            {                                                           
                                trip2.LabelsBackward.Add(label2);
                            }
                            else { label2 = default(Label); }
                        }
                    }
                }
            }               
        }
        void InitializeStartNode() //将乘务基地加入标号中
        {
            Label oLabel = new Label();
            if (direction == "Forward")
            {                
                UnProcessed[0].LabelsForward.Add(oLabel);
                //initailize(clean) labels of all trips
                for (int i = 1; i < UnProcessed.Count; i++)
                {
                    UnProcessed[i].LabelsForward.Clear();                    
                }
            }
            if (direction == "Backward")
            {
                UnProcessed.Reverse();
                //UnProcessed[0].LabelsBackward[0].AccumuConsecDrive = 0;
                //UnProcessed[0].LabelsBackward[0].AccumuDrive = 0;
                //UnProcessed[0].LabelsBackward[0].AccumuWork = 0;
                //UnProcessed[0].LabelsBackward[0].AccumuCost = 0;
                //UnProcessed[0].LabelsBackward[0].PreEdge = new Arc();
                UnProcessed[0].LabelsBackward.Add(oLabel);
                //initailize(clean) labels of all trips
                for (int i = 1; i < UnProcessed.Count; i++)
                {
                    UnProcessed[i].LabelsBackward.Clear();
                }
            }    
        }
        void InitializeBaseNode(Node trip, List<Label> label_list) //怎么确定此时的crewbase
        {
            foreach (Label label in label_list) 
            {
                foreach(CrewBase crewbase in CrewbaseList)
                {
                    if (trip.StartStation == crewbase.Station)
                    {
                        label.BaseOfCurrentPath = crewbase;
                        break;
                    }
                }
            }
            
        }
        
        Label REF(Label label, Node trip, Arc arc) //在虚拟起终点弧,顺逆向有差别，接续弧是相同的处理
            //REF作用是延申标号，通过条件判断一个点的标号是否可以延伸到另一个点上
            //松弛
        {                   
            //首先判断，避免出现 non-elementary label(path),除了基地，其余点不允许在同一Label（path）出现两次
            if (!FitNetworkConstraints(label, trip))
            {
                resource_feasible = false;
                return default(Label);                
            }            
            //bool connected = true;//是否连接成功
            Label extend = new Label();
            accumuCost = 0;
            accumuWorkday = 0;
            accumuRestday = 0;

            #region  跟据弧的类型计算Label的各项属性值            
            if (arc.ArcType == 1)//弧的类型：1-接续弧，2-出乘弧，3-退乘弧, 20-虚拟起点弧，30-虚拟终点弧
                                 //弧的类型：1-接续弧， 2-虚拟起点弧，3-虚拟终点弧
            {
                #region
                //accumuConsecDrive = label.AccumuConsecDrive + arc.Cost + trip.Length;

                //if (accumuConsecDrive >= (double)CrewRules.ConsecuDrive.min) //需要间休
                //{
                //    if (!((int)CrewRules.Interval.min <= arc.Cost && arc.Cost <= (int)CrewRules.Interval.max))//只有这种情况连接失败：需要间休，但间休时间不满足条件
                //    {
                //        //  //connected = false;                        
                //        return default(Label); 
                //    }
                //    else 
                //    {                        
                //        accumuConsecDrive = trip.Length;
                //        accumuDrive = label.AccumuDrive + trip.Length;
                //        accumuWork = label.AccumuWork + arc.Cost + trip.Length;
                //        //C  = label.AccumuCost + arc.Cost - trip.Price;
                //    }
                //}
                //else
                //{
                #endregion
                //accumuConsecDrive = label.AccumuConsecDrive + arc.Cost + trip.Length;
                //accumuDrive = label.AccumuDrive + arc.Cost + trip.Length;
                //accumuWork = label.AccumuWork + arc.Cost + trip.Length;

                accumuCost = label.AccumuCost;
                accumuWorkday = label.AccumuWorkday + trip.TypeofWorkorRest;
                accumuRestday = label.AccumuRestday + 1 - trip.TypeofWorkorRest;
                accumuWork = label.AccumuWork + trip.WorkTime;
                //C  = label.AccumuCost + arc.Cost - trip.Price;
                
                //}
            }
            //else if (arc.ArcType == 22) //跨天弧，先不和“out”弧合并
            //{
            //    accumuConsecDrive = trip.Length;
            //    accumuDrive = trip.Length;
            //    accumuWork = trip.Length;
            //    //C  = label.AccumuCost + arc.Cost - trip.Price;                                                                            
            //}
            //else if (arc.ArcType == 20) //虚拟起点弧
            //{
            //    //accumuConsecDrive = trip.Length;
            //    //accumuDrive = trip.Length;
            //    //accumuWork = trip.Length;

            //    accumuCost = trip.Length;
            //    accumuWorkday = 0;
            //    accumuRestday = 0;
            //    accumuWork =0;
            //}
            //else if (arc.ArcType == 30) //虚拟终点弧
            //{
            //    //accumuConsecDrive = label.AccumuConsecDrive;
            //    //accumuDrive = label.AccumuDrive;
            //    //accumuWork = label.AccumuWork;
            //    accumuCost = label.AccumuCost;
            //    accumuWorkday = label.AccumuWorkday + trip.TypeofWorkorRest;
            //    accumuRestday = label.AccumuRestday + 1 - trip.TypeofWorkorRest;
            //    accumuWork = label.AccumuWork + trip.WorkTime;
            //}
            
            #region // 出退乘            
            string taskType = "";//向后标号就意味着出乘弧是出弧。这部分就是把相同类型的弧合并一下，变成出弧和入弧。
            if ((arc.ArcType == 2 && direction == "Forward") || (arc.ArcType == 3 && direction == "Backward"))
            {
                taskType = "out";//弧的类型：1-接续弧，2-出乘弧，3-退乘弧, 20-虚拟起点弧，30-虚拟终点弧
            }
            if ((arc.ArcType == 3 && direction == "Forward") || (arc.ArcType == 2 && direction == "Backward"))
            {
                taskType = "back";
            }

            switch (taskType)
            {
                case "out":
                    accumuConsecDrive = trip.Length;
                    accumuDrive = trip.Length;
                    accumuWork = trip.Length;

                    //accumuWorkday = label.AccumuWorkday;
                    //accumuRestday = label.AccumuRestday;
                    //accumuWork = label.AccumuWork;
                    
                    break;
                case "back":
                    //accumuConsecDrive = label.AccumuConsecDrive;
                    //accumuDrive = label.AccumuDrive;
                    accumuWorkday = label.AccumuWorkday;
                    accumuRestday = label.AccumuRestday;
                    accumuWork = label.AccumuWork;                    
                    break;
                default:
                    taskType = "Exception";//异常
                    break;
            }
            #endregion

            #region // CHANGED 20190920 

            //string taskType = "";//向后标号就意味着出乘弧是出弧。这部分就是把相同类型的弧合并一下，变成出弧和入弧。
            //if (direction == "Forward")
            //{
            //    taskType = "out";//弧的类型：1-接续弧，2-出乘弧，3-退乘弧, 20-虚拟起点弧，30-虚拟终点弧
            //                     //1 - 接续弧， 2 - 虚拟起点弧，3 - 虚拟终点弧
            //}
            //if (direction == "Backward")
            //{
            //    taskType = "back";
            //}

            //switch (taskType)
            //{
            //    case "out":
            //        accumuConsecDrive = trip.Length;
            //        accumuDrive = trip.Length;
            //        accumuWork = trip.Length;

            //        //C  = label.AccumuCost + arc.Cost - trip.Price; 
            //        break;
            //    case "back":
            //        accumuWorkday = label.AccumuWorkday;
            //        accumuRestday = label.AccumuRestday;
            //        accumuWork = label.AccumuWork;
            //        //C  = label.AccumuCost + arc.Cost - trip.Price;
            //        break;
            //    default:
            //        taskType = "Exception";//异常
            //        break;
            //}

            #endregion

            SetCostDefinition(label, trip, arc);
            
            C -= trip.Price;

            //TODO:overed 成本最好还是抽离出去，可以对其进行多种不同的定义，比较哪种优
            #endregion
            //乘务规则
            //if (!(accumuDrive <= CrewRules.PureCrewTime && accumuWork <= CrewRules.TotalCrewTime)) //20190920 乘务规则
            if (!(accumuWork <= CrewRules.WORK_MINT 
                && accumuWorkday<= CrewRules.NUM_WORK_DAY
                && accumuRestday <= CrewRules.NUM_REST_DAY
                ))
            {
                resource_feasible = false;
            }
            else 
            {
                resource_feasible = true;
                extend.AccumuWorkday = accumuWorkday;
                extend.AccumuRestday = accumuRestday;
                extend.AccumuWork = accumuWork;
                extend.AccumuCost = C; 
                extend.PreEdge = arc;
                extend.PreLabel = label;
                extend.BaseOfCurrentPath = label.BaseOfCurrentPath;
                //TODO:新属性
                //以索引来标记trip，可能又会有bug
                if (trip.ID != 0 && trip.ID != -1)
                {
                    label.VisitedCount.CopyTo(extend.VisitedCount, 0);
                    ++extend.VisitedCount[trip.ID - 1];
                }
            }
                                                            
            return extend;
        }
        bool FitNetworkConstraints(Label label, Node trip) 
            //满足网络约束
        {
            #region
            //if (trip.LineID != 0 && label.VisitedCount[trip.LineID - 1] >= 1) 
            //{
            //    return false; //只能访问一次，elementary path
            //}
            //if (direction == "Forward") 
            //{
            //    if (trip.Type == 2 && label.BaseOfCurrentPath.Station != trip.EndStation)
            //    {
            //        return false; //path的起终基地一致
            //    }
            //}
            //else if (direction == "Backward") 
            //{
            //    if (trip.Type == 0 && label.BaseOfCurrentPath.Station != trip.StartStation)
            //    {
            //        return false;
            //    }
            //}
            #endregion
            return true;
        }
        void SetCostDefinition(Label label, Node trip, Arc arc) //TODO
        {
            switch (costType) 
            {
                case 0://求初始解时，用非乘务时间
                    C = label.AccumuCost + arc.Cost;
                    break;
                case 1://全部时间，实际上就是trip的到达时刻。迭代过程中会减去trip.Price，
                    C = label.AccumuCost + arc.Cost + trip.Length;
                    break;
                default:
                    break;
            }
        }       

        void RemainPateroLabels(ref List<Label> labelSet)//保留好的标号，不用管
        {
            
            int width = 0;
            int size = labelSet.Count;
            int index = 0;
            int first, last, mid;
            for (width = 1; width < size; width *= 2) 
            {
                for (index = 0; index < (size - width); index += width * 2) 
                {
                    first = index;
                    mid = index + width - 1;
                    //last = index + (width * 2 - 1);//两组相比较，所以是width * 2
                    //last = last >= size ? size - 1 : last;
                    last = Math.Min(index + (width * 2 - 1), size - 1);
                    CheckDominate(ref labelSet, first, mid, last);
                }
            }
            //delete labels which was dominated 
            for (index = 0; index < labelSet.Count; index++)
            {
                if (labelSet[index].Dominated == true)
                {
                    labelSet.RemoveAt(index);
                    index--;
                }
            }

        }
        void CheckDominate(ref List<Label> labelSet, int first, int mid, int last) //不用管
        {
            int i, j;
            for (i = first; i <= mid; i++) 
            {
                if (labelSet[i].Dominated) {
                    //labelSet.RemoveAt(i); i--;//先不删，反正最后统一删；现在删了反而不好处理
                    continue;
                }
                for (j = mid + 1; j <= last; j++)
                {
                    if (labelSet[j].Dominated) {
                        continue;
                    }
                    DominateRule(labelSet[i], labelSet[j]);
                }
            }
        }
        void DominateRule(Label label1, Label label2)
        {
            if(label1.BaseOfCurrentPath.Station != label2.BaseOfCurrentPath.Station)
            {
                return;
            }
            if (
                //label1.AccumuCost <= label2.AccumuCost &&
            //    label1.AccumuConsecDrive <= label2.AccumuConsecDrive &&
            //    label1.AccumuDrive <= label2.AccumuDrive &&
            //    label1.AccumuWork <= label2.AccumuWork
                label1.AccumuCost <= label2.AccumuCost &&
                label1.AccumuWorkday <= label2.AccumuWorkday &&
                label1.AccumuRestday <= label2.AccumuRestday &&
                label1.AccumuWork <= label2.AccumuWork
                )
            {
                label2.Dominated = true;
            }
            else if (
                //label2.AccumuCost <= label1.AccumuCost &&
                //label2.AccumuConsecDrive <= label1.AccumuConsecDrive &&
                //label2.AccumuDrive <= label1.AccumuDrive &&
                //label2.AccumuWork <= label1.AccumuWork
                label2.AccumuCost <= label1.AccumuCost &&
                label2.AccumuWorkday <= label1.AccumuWorkday &&
                label2.AccumuRestday <= label1.AccumuRestday &&
                label2.AccumuWork <= label1.AccumuWork
                )
            {
                label1.Dominated = true;
            }
        }

        #region 列生成找新的一列
        //public void FindNewPath()//
        //{
        //    List<Node> topoNodeList = UnProcessed;
        //    Node virD = topoNodeList.Last(); //终点的确定是否可以更加普适（少以Index为索引）
        //    Label label1;  
        //    Label label2;
        //    int i;
        //    //找标号Cost属性值最小的，改变弧长后，Cost即为reduced cost,
        //    //而主问题的Cj为 reduced cost + sum(trip.price),
        //    //但在迭代过程中Cj=1440*days
        //    #region //可利用Linq查询
        //    //label1 = virD.LabelsForward.Aggregate((l1, l2) => l1.AccumuCost < l2.AccumuCost ? l1 : l2);

        //    //label1 = (from l in virD.LabelsForward
        //    //          let minCost = virD.LabelsForward.Max(m => m.AccumuCost)
        //    //          where l.AccumuCost == minCost
        //    //          select l).FirstOrDefault();
        //    #endregion
        //    label1 = virD.LabelsForward[0];
        //    for (i = 1; i < virD.LabelsForward.Count; i++) 
        //    {                
        //        //想当然了！！常规来吧，别想着骚
        //        //label1 = virD.LabelsForward[i - 1].AccumuCost < virD.LabelsForward[i].AccumuCost ? 
        //        //         virD.LabelsForward[i - 1] : virD.LabelsForward[i];
        //        label2 = virD.LabelsForward[i];
        //        if (label1.AccumuCost > label2.AccumuCost) 
        //        {
        //            label1 = label2;
        //        }
        //    }

        //    //Reduced_Cost           = label1.AccumuCost; //2019-1-27
        //    New_Column               = new Pairing();
        //    New_Column.Arcs          = new List<Arc>();            

        //    int realistic_trip_num = NetWork.num_Physical_trip;//(nodeList.Count - 2) / CrewRules.MaxDays;
        //    //newAji                 = new int[realistic_trip_num];            
        //    //for (i = 0; i < realistic_trip_num; i++) { newAji[i] = 0; }
        //    New_Column.CoverMatrix = new int[realistic_trip_num];
        //    New_Column.Cost = label1.AccumuCost; //2019-2-1
        //    New_Column.Coef = 1440;
        //    New_Column.accumuwork = label1.AccumuWork;
        //    //double sum_tripPrice   = 0;
        //    int pathday = 1;
        //    Node virO = topoNodeList[0];
        //    Arc arc;
        //    arc = label1.PreEdge;
        //    while (!arc.O_Point.Equals(virO)) 
        //    {                
        //        New_Column.Arcs.Insert(0, arc);
        //        //sum_tripPrice += arc.O_Point.Price;
        //        //newAji[arc.O_Point.LineID - 1] = 1;
        //        if (arc.O_Point.LineID > 0) 
        //        {
        //            New_Column.CoverMatrix[arc.O_Point.LineID - 1] = 1;//虚拟起终点弧的处理
        //        }                
        //        label1 = label1.PreLabel;
        //        arc = label1.PreEdge;
        //        pathday = arc.ArcType == 22 ? pathday + 1 : pathday;
        //    }
        //    New_Column.Arcs.Insert(0, arc);
        //    //New_Path.Cost = Reduced_Cost + sum_tripPrice;            
        //    New_Column.Coef *= pathday;
        //    New_Column.ObjCoef = Net.GetObjCoef(New_Column.accumuwork , New_Column.Coef);
        #endregion

        //}
        //TODO:添加多列
        public bool FindMultipleNewPColumn(int num_addColumns)             //列生成添加检验数最小的那几个列进入列池
        {
            List<Node> topoNodeList = UnProcessed;
            Node virD = topoNodeList.Last();            
            negetiveLabels = new List<Label>();

            Reduced_Cost = 0;
            Label label1;           
            int i;
            //找标号Cost < 0即可           
            for (i = virD.LabelsForward.Count - 1; i >= 0 ; i--)
            {
                label1 = virD.LabelsForward[i];                
                if (label1.AccumuCost < 0) 
                {
                    negetiveLabels.Add(label1);
                }
            }

            if (negetiveLabels.Count == 0) //检验数均大于0，原问题最优
            {   
                return false; 
            }

            num_addColumns = Math.Min(num_addColumns, negetiveLabels.Count);
            //TODO:TopN排序，只想最多添加N列，则只需找出TopN即可   
            //先调用方法全部排序吧
            negetiveLabels = negetiveLabels.OrderBy(labelCost => labelCost.AccumuCost).ToList();

            Reduced_Cost = negetiveLabels[0].AccumuCost;//固定为最小Cost
            //reduced_costs = new double[num_addColumns];
            New_Columns = new List<Pairing>(num_addColumns);

            //局部变量                
            int realistic_trip_num = NetWork.num_Physical_trip;
            Node virO = topoNodeList[0];
            Arc arc;
           
            //newMultiAji = new int[num_addColumns, realistic_trip_num];//全部元素默认为0                

            for (i = 0; i < num_addColumns; i++)
            {
                label1 = negetiveLabels[i];
                //reduced_costs[i] = label1.AccumuCost;

                New_Column = new Pairing();
                New_Column.Arcs = new List<Arc>();
                New_Column.CoverMatrix = new int[realistic_trip_num];
                New_Column.Cost = label1.AccumuCost;
                New_Column.accumuwork = label1.AccumuWork;
                New_Column.Coef = 0;// 1440;
                int pathday = 1;

                arc = label1.PreEdge;
                while (!arc.O_Point.Equals(virO))                //主要想确定这部分的lineid的作用？该列是否覆盖line，若覆盖，系数为0
                {
                    New_Column.Arcs.Insert(0, arc);

                    New_Column.Coef += arc.Cost;

                    if (arc.O_Point.ID > 0)//lineid-车次
                    {
                        New_Column.CoverMatrix[arc.O_Point.ID - 1] = 1;
                    }

                    //pathday = arc.ArcType == 22 ? pathday + 1 : pathday;

                    label1 = label1.PreLabel;
                    arc = label1.PreEdge;
                }
                New_Column.Arcs.Insert(0, arc);
                //New_Column.Coef *= pathday;
                //New_Column.ObjCoef = Net.GetObjCoef(New_Column.accumuwork , New_Column.Coef);             

                New_Columns.Add(New_Column);
            }

            return true;
                        
        }
    }

    //调试完毕，没毛病
    public class Topological2//用来将网进行拓扑一下，将网按顺序排列一下
    {
        private Queue<Node> queue;
        //private int[] Indegree;
        private Dictionary<Node, int> Indegree;         

        public List<Node> Order;//拓扑序列

        /// <summary>
        /// Network , strat point
        /// </summary>
        /// <param name="net"></param>
        /// <param name="s"></param>
        public Topological2(NetWork net, Node s)                                                 //拓扑的内容，不用看
        {
            List<Node> nodeset = net.NodeSet;
            Node trip;
            queue = new Queue<Node>();            
            Indegree = new Dictionary<Node, int>();

            Order = new List<Node>();
            for (int i = 0; i < nodeset.Count; i++) 
            {
                trip = nodeset[i];
                Indegree[trip] = trip.In_Edges.Count; 
            }           

            //TODO：check error ：id为0的点没有入弧，
            foreach (Node node in nodeset)
            {
                if (node.In_Edges.Count == 0)
                {
                    queue.Enqueue(node);
                }
            }

            int count = 0;
            while (queue.Count != 0)
            {
                Node Top = queue.Dequeue();
                int top = Top.ID;
                Order.Add(Top);
                foreach (var arc in net.ArcSet)
                {
                    if (arc.O_Point == Top && arc.D_Point.ID != -1) //终点在最后
                    {
                        if (--Indegree[arc.D_Point] == 0)
                        {
                            queue.Enqueue(arc.D_Point);
                        }
                    }
                }
                count++;
            }
            Order.Add(nodeset[1]);//终点
            count++;
            if (count != nodeset.Count) { throw new Exception("此图有环"); }

        }
    }
}
