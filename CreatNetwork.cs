using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//建网在我看来就是在程序中把所有的点和线记录下来

namespace CG_CSP_1440//crewbase可以直接把文件里的内容删除，在这里就没有影响了。
{
    public struct CrewRules
    {
        const int INF = 99999;
        #region 乘务规则参数设置,初始解，最短路中的参数 = 该处，则只需在建网时更改参数
        public static int minTransTime = 15;        
        //public static int[] Interval = new int[2] { 30, 120 };
        public enum Interval { min = 30, max = 120 }
        //public static int ConsecuDrive = 180;//铭-240;岩-180
        public enum ConsecuDrive { min = INF, max = INF }//180, max = 250 }
        public static int PureCrewTime = INF;//360;//京津360same //等价于哲铭中的minDayCrewTime
        public static int TotalCrewTime = INF;//480;//铭-540;岩-480 //等价于哲铭中的maxDayCrewTime
        //public static int NonBaseRest = 960;//铭-720;岩-960
        public enum NonBaseRest//外段驻班时间
        {
            //min = 720,
            //max = 1200  //设置时间窗，为了减少弧
            min=INF,
            MAX = INF
        }
        public static int maxLength = INF;//1440;//先一样
        public static int MaxDays = 2;
        public static double average_time = INF;//400;

        #endregion

        public static int NUM_WORK_DAY = 4;
        public static int NUM_REST_DAY = 4;
        public static int WORK_MINT = 2880;
    }
    
    public class NetWork
    {
        public  List<Node> NodeSet;
        public List<Node> TripList;
        public List<Node> IDList;
        public List<Node> WorkIDList;
        public List<Node> LineIDList;
        public List<Node> LineList;
        public List<Arc> ArcSet;
        public List<Node> DNodeList;
        public List<Node> ONodeList;
        static int num_physical_trip;

        public Dictionary<int, List<int>> RouteID_TripIDs_Map;//20191005
        public Dictionary<int, List<int>> Day_TripIDs_Map;

        public static int num_Physical_trip 
        {
            get { return num_physical_trip; }  
            set { num_Physical_trip = value; }          
        }
        ///
        #region 乘务规则参数设置, 只需在建网时更改参数
        int TransTime           = CrewRules.minTransTime;
        //int minInterval         = (int)CrewRules.Interval.min;
        //int maxInterval         = (int)CrewRules.Interval.max;
        //int minConsecuDrive     = (int)CrewRules.ConsecuDrive.min;//铭-240;岩-180
        //int maxConsecuDrive     = (int)CrewRules.ConsecuDrive.max;
        int PureCrewTime        = CrewRules.PureCrewTime;//same
        int TotalCrewTime       = CrewRules.TotalCrewTime;//铭-540;岩-480
        //int minNonBaseRest      = (int)CrewRules.NonBaseRest.min;//铭-720;岩-960
        //int maxNonBaseRest      = (int)CrewRules.NonBaseRest.max;
        int Longest             = CrewRules.maxLength;//先一样
        int MaxDays             = CrewRules.MaxDays;

        #endregion
        public double GetObjCoef(double accumuwork , double coef)//coef-cj          objcoef-枭楠特制，不要
            //accumuwork-累积工作时间
        {
            if(accumuwork <= CrewRules.average_time)
            {
                return coef;
            }
            else
            {
                return accumuwork - CrewRules.average_time + coef;
            }
        }
        public void CreateNetwork(string ConnStr) 
        {
            DataReader Data = new DataReader();
            //Data.Ds = Data.ConnSQL(ConnStr);
            //Data.LoadData_sql(Data.Ds, MaxDays);
            List<string> csvfiles;
            Data.Connect_csvs(out csvfiles);
            Data.LoadData_csv(MaxDays);

            //建弧
            this.NodeSet = Data.NodeSet;
            this.TripList = Data.TripList;

            ArcSet = new List<Arc>();
            int i, j;
            //20191005
            RouteID_TripIDs_Map = new Dictionary<int, List<int>>();
            for (i = 0; i < TripList.Count; i++) {
                int route_id = TripList[i].RoutingID;
                if (!RouteID_TripIDs_Map.ContainsKey(route_id)) {
                    RouteID_TripIDs_Map[route_id] = new List<int>();
                }
                RouteID_TripIDs_Map[route_id].Add(i);
            }
            Day_TripIDs_Map = new Dictionary<int, List<int>>();
            for (i = 0; i < TripList.Count; i++)
            {
                int day = TripList[i].DayofRoute;
                if (!Day_TripIDs_Map.ContainsKey(day))
                {
                    Day_TripIDs_Map[day] = new List<int>();
                }
                Day_TripIDs_Map[day].Add(i);
            }
            //end 20191005

            Node trip1, trip2,trip3;
            //int length = 0;
            Node virO = NodeSet[0];
            Node virD = NodeSet[1];
            
            List<Node> odBase = Data.ODBaseList;
            List<Node> oNode = Data.ONodeList;
            List<Node> dNode = Data.DNodeList;

            DNodeList = Data.DNodeList;


            foreach (var node in oNode) //changed 20190920
            {

                Arc arc = new Arc();
                arc.O_Point = virO;
                arc.D_Point = node;
                arc.Cost = 0;
                arc.ArcType = 2; //1-接续弧， 2-虚拟起点弧，3-虚拟终点弧
                ArcSet.Add(arc);
                virO.Out_Edges.Add(arc);
                node.In_Edges.Add(arc);

            }
            foreach (var node in dNode) //TODO
            {
                Arc arc = new Arc();
                arc.O_Point = node;
                arc.D_Point = virD;
                arc.Cost = 0;
                arc.ArcType = 3; //1-接续弧， 2-虚拟起点弧，3-虚拟终点弧
                ArcSet.Add(arc);
                node.Out_Edges.Add(arc);
                virD.In_Edges.Add(arc);
            }


            for (i = 0; i < TripList.Count -1; i++) //trip1·trip2都是节点
            {
              
                trip1 = TripList[i];
                trip3 = TripList[i+1];

                //Console.WriteLine("satrt!!");
                //Console.Write("trip1: name: {0}, work type{1}\n", trip1.Name, trip1.TypeofWorkorRest);

                //if (trip1.ID == 6 || trip1.ID == 7) {

                //    int debug = 0;
                //}

                if(trip3.DayofRoute!=0)
                {
                    for (j = 0; j < TripList.Count; j++)
                    {
                        if (i == j)
                        {
                            continue;
                        }

                        trip2 = TripList[j];
                        //Console.Write("trip2: name: {0}, work type{1} \n \n", trip1.Name, trip1.TypeofWorkorRest);

                        // 请假
                        if (trip3.TypeofLeave == 0)
                        {
                            if (j == i + 1)
                            {
                                continue;
                            }
                        }

                        if (trip1.LengthofRoute == trip2.LengthofRoute
                            &&(trip1.DayofRoute + 1 == trip2.DayofRoute)
                            && (trip1.TypeofWork >= trip2.TypeofWork /*|| trip1.TypeofWork > trip2.TypeofWork*/)
                            && (trip3.TypeofWorkorRest != trip2.TypeofWorkorRest || trip1.Name == trip2.Name))  //1,2所属的交路长度相同
                        {

                            Arc arc = new Arc();           //这里就是建立接续弧
                            arc.O_Point = trip1;
                            arc.D_Point = trip2;
                            if (trip1.TypeofWork == trip2.TypeofWork)//同类型员工之间的替班
                            {
                                if (trip1.Name == trip2.Name)
                                {
                                    arc.Cost = 0;
                                }
                                else if (trip1.RoutingID == trip2.RoutingID)
                                {
                                    arc.Cost = 1;
                                }
                                else if (trip1.RoutingID != trip2.RoutingID)
                                {
                                    arc.Cost = 10;
                                }
                            }
                            else if (trip1.TypeofWork < trip2.TypeofWork)//乘务长给乘务员替班
                            {
                                if (trip1.RoutingID == trip2.RoutingID)
                                {
                                    arc.Cost = 2;
                                }
                                else if (trip1.RoutingID != trip2.RoutingID)
                                {
                                    arc.Cost = 20;
                                }
                            }
                            else if (trip1.TypeofWork > trip2.TypeofWork)//乘务员给乘务长替班
                            {
                                arc.Cost = 666666666;
                            }

                            arc.ArcType = 1;              //1-接续弧
                            ArcSet.Add(arc);
                            trip1.Out_Edges.Add(arc);
                            trip2.In_Edges.Add(arc);

                            Console.Write("arc:<{0}, {1}>", trip1.ID, trip2.ID);
                            Console.Write("connected!! <trip1_{0}: name: {1}, work type {2}>," +
                                                        "<trip2_{3}: name: {4}, work type {5}> " +
                                                        "<teip3_{6}: name:{7}, 是否请假 {8}>\n",
                                                        trip1.ID,trip1.Name, trip1.TypeofWorkorRest,
                                                        trip2.ID,trip2.Name, trip2.TypeofWorkorRest,
                                                        trip3.ID,trip3.Name, trip3.TypeofLeave);

                            #region pre version

                            //if (trip1.DayofRoute == trip2.DayofRoute + 1)//trip2比trip1多一天
                            //{
                            //    if (trip1.TypeofWork == trip2.TypeofWork || trip1.TypeofWork > trip2.TypeofWork)
                            //    //乘务员和乘务长不能互联，0-乘务员，1-乘务长
                            //    {
                            //        if (trip3.TypeofWorkorRest != trip1.TypeofWorkorRest || trip1.Name == trip2.Name)
                            //        //0-休,1-作;这一条是保证只能连接个人的点或者与自己作休状态不同的点
                            //        {
                            //            Arc arc = new Arc();           //这里就是建立接续弧
                            //            arc.O_Point = trip1;
                            //            arc.D_Point = trip2;
                            //            if (trip1.TypeofWork == trip2.TypeofWork)//同类型员工之间的替班
                            //            {
                            //                if (trip1.Name == trip2.Name)
                            //                {
                            //                    arc.Cost = 0;
                            //                }
                            //                else if (trip1.RoutingID == trip2.RoutingID)
                            //                {
                            //                    arc.Cost = 1;
                            //                }
                            //                else if (trip1.RoutingID != trip2.RoutingID)
                            //                {
                            //                    arc.Cost = 10;
                            //                }
                            //            }
                            //            else if (trip1.TypeofWork < trip2.TypeofWork)//乘务长给乘务员替班
                            //            {
                            //                if (trip1.RoutingID == trip2.RoutingID)
                            //                {
                            //                    arc.Cost = 2;
                            //                }
                            //                else if (trip1.RoutingID != trip2.RoutingID)
                            //                {
                            //                    arc.Cost = 20;
                            //                }
                            //            }
                            //            else if (trip1.TypeofWork > trip2.TypeofWork)//乘务员给乘务长替班
                            //            {
                            //                arc.Cost = 666666666;
                            //            }

                            //            arc.ArcType = 1;              //1-接续弧
                            //            ArcSet.Add(arc);
                            //            trip1.Out_Edges.Add(arc);
                            //            trip2.In_Edges.Add(arc);
                            //        }
                            //    }
                            //}

                            #endregion
                        }
                    }
                    #region
                    //    if (trip1 != trip2 && trip1.EndStation == trip2.StartStation && length > 0)//如果节点1和节点2不是同一个点，并且1的
                    //        //终点站与2的起点站相同并且这两个节点之间有距离
                    //    {
                    //        //if ((trip1.RoutingID == trip2.RoutingID) ||
                    //        //    (trip1.RoutingID != trip2.RoutingID &&
                    //        //    ((TransTime <= length && length <= Interval[1]) ||
                    //        //    (trip2.StartTime > 1440 && trip1.EndTime < 1440 && minNonBaseRest <= length && length <= maxNonBaseRest))))
                    //        if (trip1.RoutingID == trip2.RoutingID || Transferable(trip1, trip2, length))//顺序不能变，
                    //            //因为是通过逻辑转换才将上面的简化为这样。    中间的符号是逻辑“或”，或后面的意思是是否可以接续
                    //            //这里的意思是如果trip1和trip2是同一条交路里的或者这两点满足接续条件
                    //        {
                    //            Arc arc = new Arc();           //这里就是建立接续弧
                    //            arc.O_Point = trip1;
                    //            arc.D_Point = trip2;
                    //            arc.Cost = length;
                    //            arc.ArcType = length >= minNonBaseRest ? 22 : 1;//22-跨天了
                    //            ArcSet.Add(arc);
                    //            trip1.Out_Edges.Add(arc);
                    //            trip2.In_Edges.Add(arc);
                    //        }
                    //    }
                    //}
                    //else if (trip1.EndStation == trip2.StartStation && trip1.Type == 0 && trip2.Type == 1)
                    //    //这种情况是节点1和2的种类不同。当节点1的终到站和2的起点站相同并且节点1是始发基地，节点2是普通节点
                    //{                        

                    //        Arc arc = new Arc();
                    //        arc.O_Point = trip1;
                    //        arc.D_Point = trip2;
                    //        arc.Cost = trip2.StartTime;
                    //        arc.ArcType = 2;//弧的类型：1-接续弧，2-出乘弧，3-退乘弧, 20-虚拟起点弧，30-虚拟终点弧
                    //    ArcSet.Add(arc);
                    //        trip1.Out_Edges.Add(arc);
                    //        trip2.In_Edges.Add(arc);                                                                        
                    //}
                    //else if (trip1.EndStation == trip2.StartStation && trip1.Type == 1 && trip2.Type == 2)
                    //{
                    //    Arc arc = new Arc();
                    //    arc.O_Point = trip1;
                    //    arc.D_Point = trip2;
                    //    int d = (trip1.EndTime / 1440 + 1);
                    //    arc.Cost = 1440 * d - trip1.EndTime;
                    //    arc.ArcType = 3;//退乘弧
                    //    ArcSet.Add(arc);
                    //    trip1.Out_Edges.Add(arc);
                    //    trip2.In_Edges.Add(arc);
                    //}    
                    #endregion
                }                                
            }
            //原始区段数
            //num_physical_trip = (NodeSet.Count - 2 - 2 * DataReader.CrewBaseList.Count) / CrewRules.MaxDays;
            num_physical_trip = TripList.Count;

            #region CheckTestArcs
            //foreach (Arc arc in ArcSet) 
            //{
            //    Console.WriteLine(arc.O_Point.ID + " -> " + arc.D_Point.ID + " type: " + arc.ArcType);
            //}
            #endregion
            //删去出度或入度为0的点与弧
            DeleteUnreachableNodeandEdge(ref TripList);            
            
        }
        #region
        //bool Transferable(Node trip1, Node trip2, int length)//在这里定义接续规则
        //{
        //    bool sameDay = false;
        //    bool differentDay = false;
        //    if(TransTime <= length)
        //    {              
        //        if (trip1.EndTime < 1440 && trip2.StartTime > 1440)
        //        {
        //            differentDay = minNonBaseRest <= length && length <= maxNonBaseRest;
        //        }
        //        else 
        //        {
        //            sameDay = length <= maxInterval;
        //        }
        //    }            
        //    return sameDay || differentDay;
        //}
        #endregion

        void DeleteUnreachableNodeandEdge(ref List<Node> TripList) //删除不可达的点和边
        {
            int i = 0, j, k;
            Arc edge1, edge2;
            Node trip1, trip2;//trip乘务区段，也就是节点
            for (i = 0; i < TripList.Count; i++)
            {
                trip1 = TripList[i];
                if (trip1.Out_Edges.Count == 0 || trip1.In_Edges.Count == 0)
                {
                    #region//删去 出度 = 0 的点的 In_Edges
                    for (j = 0; j < trip1.In_Edges.Count; j++)
                    {
                        edge1 = trip1.In_Edges[j];
                        trip2 = edge1.O_Point;
                        for (k = 0; k < trip2.Out_Edges.Count; k++)
                        {
                            edge2 = trip2.Out_Edges[k];
                            if (edge1 == edge2)
                            {
                                trip2.Out_Edges.RemoveAt(k);
                                break;//只可能有一条，所以找到了删去后，不用再继续寻找，减少了搜索次数
                            }
                        }
                        //上面这个for循环改为：
                        //if (trip2.Out_Edges.Contains(edge1)) 
                        //{
                        //    trip2.Out_Edges.Remove(edge1);
                        //}

                        for (k = 0; k < ArcSet.Count; k++)
                        {
                            edge2 = ArcSet[k];
                            if (edge1 == edge2)
                            {
                                ArcSet.RemoveAt(k);
                                break;
                            }
                        }
                    }
                    #endregion
                    #region//删去 入度 = 0的点的 Out_Edges
                    for (j = 0; j < trip1.Out_Edges.Count; j++)
                    {
                        edge1 = trip1.Out_Edges[j];
                        trip2 = edge1.D_Point;
                        for (k = 0; k < trip2.In_Edges.Count; k++)
                        {
                            edge2 = trip2.In_Edges[k];
                            if (edge1 == edge2)
                            {
                                trip2.In_Edges.RemoveAt(k); k--;
                                break;
                            }
                        }
                        for (k = 0; k < ArcSet.Count; k++)
                        {
                            edge2 = ArcSet[k];
                            if (edge1 == edge2)
                            {
                                ArcSet.RemoveAt(k); k--;
                                break;
                            }
                        }
                    }
                    #endregion
                    TripList.RemoveAt(i);
                    NodeSet.Remove(trip1);
                    i--;
                }
            }
        
        }

        public void IsAllTripsCovered() 
        {
            List<int> copy_LinesID = CopyLinesID(TripList);
            List<int> unCoveredTrips = new List<int>();
            try
            {
                FindUncoveredTrips(copy_LinesID,out unCoveredTrips);
            }
            catch (TripUncoveredException ex)
            {
                Console.WriteLine("{0}\n检查乘务基地设置或复制天数是否有误", ex.Message);
                OutUncoveredTrips(unCoveredTrips);
            }            
        }
        List<int> CopyLinesID(List<Node> TripList)//这里复制车次的作用？？？？？？？？？？？？？？？？？？？？？？？？？？？
        {
            List<int> copy_LineIDs = new List<int>();
            for (int i = 0; i < TripList.Count; i++)//
            {
                if (!copy_LineIDs.Contains(TripList[i].ID))
                    //这里不清楚应该用什么来对应LineID？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？？
                {
                    copy_LineIDs.Add(TripList[i].ID);
                }
            }
            return copy_LineIDs;
        }
        void FindUncoveredTrips(List<int> copy_LinesID, out List<int> unCoveredTrips) 
        {
            unCoveredTrips = new List<int>();
            int i = 0;
            for (i = 1; i <= num_Physical_trip; i++)
            {
                if (!copy_LinesID.Contains(i))
                {
                    unCoveredTrips.Add(i);
                    //break;//只加break更注重只要存在uncovered点就行，不需知道是哪个点uncovered，因而信息不明确
                }
            }
            if (unCoveredTrips.Count > 0) {
                throw new TripUncoveredException("存在未被覆盖的点!");
            }

            //return unCoveredTrips;
        }
        void OutUncoveredTrips(List<int> unCoveredTrip) {
            Console.WriteLine("uncovered trips id: ");
            foreach (int trip in unCoveredTrip) {
                Console.Write(trip + ", ");
            }
        }

        public class TripUncoveredException : ApplicationException
        {
            //const string Message = "存在未被覆盖的点";
            public TripUncoveredException() { }
            public TripUncoveredException(string message) : base(message) { }
        }
    }

}
