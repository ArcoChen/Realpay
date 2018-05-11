using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ReCommon
{
    public class SingleXmlInfo
    {
        /// <summary>
        /// 静态变量保存类的实例
        /// </summary>
        private static SingleXmlInfo uniqueInstance;

        // 定义一个标识确保线程同步
        private static readonly object locker = new object();

        /// <summary>
        /// 定义私有构造函数
        /// </summary>
        private SingleXmlInfo()
        {

        }

        /// <summary>
        /// 定义公有方法提供一个全局访问点,同时你也可以定义公有属性来提供全局访问点
        /// </summary>
        /// <returns></returns>
        public static SingleXmlInfo GetInstance()
        {
            // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
            // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
            // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
            // 双重锁定只需要一句判断就可以了
            if (uniqueInstance == null)
            {
                lock (locker)
                {
                    // 如果类的实例不存在则创建，否则直接返回
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new SingleXmlInfo();
                    }
                }
            }
            return uniqueInstance;
        }

        #region XmlDocument
        /// <summary>  
        ///   加载本地Xml文件并查找根节点  
        /// </summary>  
        /// <param name="singleNode">传入要查找的节点</param>  
        /// <returns></returns>  
        public XmlNode getXMLConfigRoot(string singleNode)
        {
            //创建一个XmlDocument对象  
            XmlDocument xmlDoc = new XmlDocument();
            //定义并获取程序运行时的本地路径  
            String xmlPath = System.Environment.CurrentDirectory;

            //WebApiConfig.xml文件  
            if (!File.Exists(xmlPath + "\\WebApiConfig.xml"))
            {
                throw new Exception("This File isn't Exist!");
            }
            //WebApiConfig.xml文件  
            xmlDoc.Load(xmlPath + "\\WebApiConfig.xml");

            //选中SystemConfig.xml文件中的根节点  
            XmlNode root = xmlDoc.SelectSingleNode("SystemConfigs");

            //定义需要查找的节点  
            XmlNode NeedRoot = null;
            //遍历根节点下的所有子节点  
            foreach (XmlNode childNode in root.ChildNodes)
            {
                //如果遍历得到的子节点与所需要查找的节点相同，则返回该节点  
                if (childNode.Name.Equals(singleNode))
                {
                    NeedRoot = root.SelectSingleNode(singleNode);
                }
            }
            return NeedRoot;
        }

        /// <summary>
        /// 获取节点对应的值
        /// </summary>
        /// <param name="Node">节点名称</param>
        /// <returns>xml值</returns>
        public string getPersonalContactInfo(string Node)
        {
            //得到所需的节点属性的父节点  
            XmlNode NeededRoot = getXMLConfigRoot(Node);

            //定义变量用于暂时保存获取出来的节点属性的值  
            string NeedValue = "";
            //如果所需杰节点属性的父节点不存在,则抛出错误信息  
            if (NeededRoot == null)
            {
                throw new Exception("读取配置节点SelfPrePhone文件错误");
            }
            ////遍历所需节点的所有属性，并返回所查找的属性的值  
            //foreach (XmlNode NeedTypeChildNode in NeededRoot.ChildNodes)
            //{
            //    NeedValue = NeedTypeChildNode.Attributes[type].Value;
            //}
            return NeedValue;
        }
        #endregion

        public string GetWebApiConfig(string Name)
        {
            string Result = string.Empty;

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;
            settings.IgnoreWhitespace = true;

            string XmlFilePath = System.AppDomain.CurrentDomain.BaseDirectory + "WebApiConfig.xml";

            try
            {
                using (XmlReader reader = XmlReader.Create(XmlFilePath, settings))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            string elementName = reader.Name;
                            if (elementName == Name)
                            {
                                if (reader.Read())
                                {
                                    return reader.Value;
                                }
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
            }

            return Result;
        }

    }
}
