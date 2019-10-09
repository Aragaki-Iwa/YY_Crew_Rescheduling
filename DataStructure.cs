using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ILOG.Concert;
using ILOG.CPLEX;

namespace CG_CSP_1440
{
    
    public  class Label //标号
                                                          //复习一下标号法
    {
        public int ID;
        public double AccumuCost = 0;//总接续时间，非乘务时间，目标函数系数                 总替班成本
        public double AccumuWorkday = 0;//从源点至当前点 累计连续驾驶时间，                 总工作天数
        public double AccumuRestday = 0;//从源点至当前点 累计驾驶时间，即纯乘务时间         总休息天数
        public double AccumuWork = 0;//即总乘务时间                                         总工时

        public Arc PreEdge;
        public Label PreLabel;
        public bool Dominated = false;
        //TODO：先记着这个成员是刚添加的,net还未建立，故DataFromSQL中virO,VirD的label.VisitedCount.Length = 0,改进
        //对O，D的VisitedCount重新初始化，in DataFromSQL
        public int[] VisitedCount = new int[NetWork.num_Physical_trip];
        public CrewBase BaseOfCurrentPath;//= new CrewBase();//2019-1-25 化多基地为单基地需要对交路加以限制
        //不需要每个Label都new一个，只需new base数量个，然后每个Label的对应optbase指向它

        public Label() 
        {            
            for (int i = 0; i < NetWork.num_Physical_trip; i++)
            {
                VisitedCount[i] = 0;
            }
        }
    }
    public class Pairing //计算出的结果，也就是一条交路
    {
        public List<Arc> Arcs;
        public double Cost;
        public double Coef;
        public double ObjCoef;
        public double accumuwork;

        public int[] CoverMatrix;//2019-1-26               matrix模型
        /// <summary>
        /// 输入，每个crew固定，对应记录crew对应的计划工作状态，
        /// </summary>
        public int[] workVector;
        /// <summary>
        /// 该工作链属于哪个crew
        /// </summary>
        public int crewID;

    }
    public class Node
    {
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        private string name;//节点所属乘务员姓名
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int crewID;
        public int CrewID {
            get { return crewID; }
            set { crewID = value; }
        }

        private int dayofRoute;
        /// <summary>
        /// 交路所处天数 其中第0天代表这个点是一个身份节点
        /// </summary>
        public int DayofRoute
        {
            get { return dayofRoute; }
            set { dayofRoute = value; }
        }
        private string startStation;//出发车站
        public string StartStation
        {
            get { return startStation; }
            set { startStation = value; }
        }
        private string endStation;//到达车站
        public string EndStation
        {
            get { return endStation; }
            set { endStation = value; }
        }

        private int workTime;//工作时长
        public int WorkTime
        {
            get { return workTime; }
            set { workTime = value; }
        }
        private int restTime;//休息时长
        public int RestTime
        {
            get { return restTime; }
            set { restTime = value; }
        }
        private int lengthofRoute;//所属交路长度
        public int LengthofRoute
        {
            get { return lengthofRoute; }
            set { lengthofRoute = value; }
        }
        private int typeofWork;
        /// <summary>
        /// 身份信息 0-乘务员，1-乘务长                
        /// </summary>
        public int TypeofWork
        {
            get { return typeofWork; }
            set { typeofWork = value; }
        } 
        private int typeofWorkorRest;
        /// <summary>
        /// 作休类型 1-作，0-休    
        /// </summary>
        public int TypeofWorkorRest
        {
            get { return typeofWorkorRest; }
            set { typeofWorkorRest = value; }
        }

        private int routingID;//所属交路编号
        public int RoutingID
        {
            get { return routingID; }
            set { routingID = value; }
        }
               
        private int typeofLeave;
        /// <summary>
        /// 是否请假 0-是，1-否
        /// </summary>
        public int TypeofLeave  
        {
            get { return typeofLeave; }
            set { typeofLeave = value; }
        }

        private int numberofWorkday;//交路所需工作天数
        public int NumberofWorkday
        {
            get { return numberofWorkday; }
            set { numberofWorkday = value; }
        }
        private int numberofRestday;//交路所需休息天数
        public int NumberofRestday
        {
            get { return numberofRestday; }
            set { numberofRestday = value; }
        }

        public double Length;
        public double Price;
        //public bool Visited;
        public List<Label> LabelsForward = new List<Label>();
        public List<Label> LabelsBackward = new List<Label>();
        public List<Arc> Out_Edges = new List<Arc>();
        public List<Arc> In_Edges = new List<Arc>();

        public int numVisited = 0;
    }
    public class Arc
    {
        //private int id;
        //public int ID
        //{
        //    get { return id; }
        //    set { id = value; }
        //}       
        private Node startPoint;
        public Node O_Point
        {
            get { return startPoint; }
            set { startPoint = value; }
        }
        private Node endPoint;
        public Node D_Point
        {
            get { return endPoint; }
            set { endPoint = value; }
        }
        private double cost;//弧长，即替班成本
        public double Cost
        {
            get { return cost; }
            set { cost = value; }
        }
        private int arcType;//弧的类型：1-接续弧， 2-虚拟起点弧，3-虚拟终点弧
        public int ArcType
        {
            get { return arcType; }
            set { arcType = value; }
        }

    }

    public struct CrewBase {
        public  int ID;
        public string Station;
        
    }

    public class TreeNode //根节点，暂时不管
    {
        public double obj_value;
        public List<int> fixing_vars;
        public Dictionary<int, double> not_fixed_var_value_pairs; //由于每次找最大的Value对应的key，所以可以用一个最大堆来优化
        /// <summary>
        /// 这是回溯"剪枝"剪掉的变量，不得再被二次分支
        /// </summary>
        public List<int> fixed_vars;

        public TreeNode() 
        {
            fixing_vars = new List<int>();
            not_fixed_var_value_pairs = new Dictionary<int, double>();
            fixed_vars = new List<int>();
        }
    }

    //public class Dvar : INumVar 
    //{
    //    public double value_;
    //    public NumVarType type_;

    //    public Dvar() 
    //    {
        
    //    }

    //    public double Value() 
    //    {
        
    //    }

    //}

}
