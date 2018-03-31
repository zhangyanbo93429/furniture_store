using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Xml;
using System.Collections;

using Microsoft.Office.Core;
namespace PuTianCheng
{
    /// <summary>
    /// XmlHelper 的摘要说明
    /// </summary>
    public class XmlHelper
    {
        string path;
        string rootNodename;
        string furniture;
        string[,] attributes;
        cmdXML cx;
        storeFur sf;
        public XmlHelper()
        {
            path = @"mainStore.xml";
            rootNodename = @"store";           
            cx = new cmdXML();
        }

        //打开Xml,如不存在，则创建之
        public void CreateXML(string xmlname)
        {
            //初始化一个xml实例
            XmlDocument myXmlDoc = new XmlDocument();
            try
            {
                myXmlDoc.Load(xmlname);
            }
            catch
            {
                cx.CreateXMLDoc(xmlname, rootNodename);
            }
        }
        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="node">节点</param>
        /// <param name="attribute">属性名，非空时返回该属性值，否则返回串联值</param>
        /// <returns>string</returns>
        /**************************************************
         * 使用示列:
         * XmlHelper.Read(path, "/Node", "")
         * XmlHelper.Read(path, "/Node/Element[@Attribute='Name']", "Attribute")
         ************************************************/
        public string Read(string node, string attribute)
        {
            string value = "";
            try
            {
                XmlDocument doc = new XmlDocument();
            
                doc.Load(path);
                XmlNode xn = doc.SelectSingleNode(node);
              

                value = (attribute.Equals("") ? xn.InnerText : xn.Attributes[attribute].Value);
               
            }
            catch { }
            return value;
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="node">节点</param>
        /// <param name="element">元素名，非空时插入新元素，否则在该元素中插入属性</param>
        /// <param name="attribute">属性名，非空时插入该元素属性值，否则插入元素值</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        /**************************************************
         * 使用示列:
         * XmlHelper.Insert(path, "/Node", "Element", "", "Value")
         * XmlHelper.Insert(path, "/Node", "Element", "Attribute", "Value")
         * XmlHelper.Insert(path, "/Node", "", "Attribute", "Value")
         ************************************************/
        public void Insert(string node, string element, string attribute, string value)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode xn = doc.SelectSingleNode(node);
                if (element.Equals(""))
                {
                    if (!attribute.Equals(""))
                    {
                        XmlElement xe = (XmlElement)xn;
                        xe.SetAttribute(attribute, value);
                    }
                }
                else
                {
                    XmlElement xe = doc.CreateElement(element);
                    if (attribute.Equals(""))
                        xe.InnerText = value;
                    else
                        xe.SetAttribute(attribute, value);
                    xn.AppendChild(xe);
                }
                doc.Save(path);
            }
            catch { }
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="node">节点</param>
        /// <param name="attribute">属性名，非空时修改该节点属性值，否则修改节点值</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        /**************************************************
         * 使用示列:
         * XmlHelper.Insert(path, "/Node", "", "Value")
         * XmlHelper.Insert(path, "/Node", "Attribute", "Value")
         ************************************************/
        public void Update(string node, string attribute, string value)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode xn = doc.SelectSingleNode(node);
                XmlElement xe = (XmlElement)xn;
                if (attribute.Equals(""))
                    xe.InnerText = value;
                else
                    xe.SetAttribute(attribute, value);
                doc.Save(path);
            }
            catch { }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="node">节点</param>
        /// <param name="attribute">属性名，非空时删除该节点属性值，否则删除节点值</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        /**************************************************
         * 使用示列:
         * XmlHelper.Delete(path, "/Node", "")
         * XmlHelper.Delete(path, "/Node", "Attribute")
         ************************************************/
        public void Delete( string node, string attribute)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode xn = doc.SelectSingleNode(node);
                XmlElement xe = (XmlElement)xn;
                if (attribute.Equals(""))
                    xn.ParentNode.RemoveChild(xn);
                else
                    xe.RemoveAttribute(attribute);
                doc.Save(path);
            }
            catch { }
        }
    }
    public class cmdXML
    {


        /// <summary>
        /// 创建XML文件
        /// </summary>
        /// <param name="xmlFilePath">存放目录</param>
        /// <param name="rootNodename">根节点名字</param>
        public void CreateXMLDoc(string xmlFilePath, string rootNodename)
        {
            XmlDocument myXmlDoc = new XmlDocument();
            try
            {
                myXmlDoc.Load(xmlFilePath);
            }
            catch
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlDeclaration xdDec = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
                XmlElement xeRoot = xmlDoc.CreateElement(rootNodename);
                xmlDoc.AppendChild(xdDec);
                xmlDoc.AppendChild(xeRoot);
                xmlDoc.Save(xmlFilePath);
                
            }
        }
        /// <summary>
        /// 增加节点属性
        /// </summary>
        /// <param name="xmlFilePath">文件路径</param>
        /// <param name="stf">家具类</param>
        public void AddFurElement(string xmlFilePath,storeFur stf,string rootNodeName)
        {
            
            XmlDocument myXmlDoc = new XmlDocument();
            myXmlDoc.Load(xmlFilePath);
            XmlNode memberlist = myXmlDoc.SelectSingleNode(rootNodeName);
            XmlElement element = myXmlDoc.CreateElement("furniture");
            element.SetAttribute("date", stf.date);
            XmlNode subnode = memberlist.AppendChild(element);

            element = myXmlDoc.CreateElement("variety");
            element.InnerText = stf.variety;
            subnode.AppendChild(element);

            element = myXmlDoc.CreateElement("number");
            element.InnerText = stf.number;
            subnode.AppendChild(element);

            element = myXmlDoc.CreateElement("inprice");
            element.InnerText = stf.inprice;
            subnode.AppendChild(element);

            element = myXmlDoc.CreateElement("onprice");
            element.InnerText = stf.onprice;
            subnode.AppendChild(element);

            element = myXmlDoc.CreateElement("outprice");
            element.InnerText = stf.outprice;
            subnode.AppendChild(element);

            element = myXmlDoc.CreateElement("date");
            element.InnerText = stf.date;
            subnode.AppendChild(element);

            
            myXmlDoc.Save(xmlFilePath);
        }

        //搜索rootNodeName下所有节点
        public ArrayList searchAllNode(string xmlFilePath, string rootNodeName)
        {
            ArrayList al = new ArrayList();
            XmlDocument xd = new XmlDocument();
            xd.Load(xmlFilePath);
            XmlNode xn = xd.SelectSingleNode(rootNodeName);
            XmlNodeList xl = xn.ChildNodes;
            foreach(XmlNode xxn in xl)
            {
                string[] str ={ xxn.ChildNodes[0].InnerText, xxn.ChildNodes[1].InnerText, xxn.ChildNodes[2].InnerText, xxn.ChildNodes[3].InnerText, xxn.ChildNodes[4].InnerText, xxn.ChildNodes[5].InnerText };
                storeFur stf = new storeFur(str);
                al.Add(stf);
            }
            return al;
        }
        //删除rootNodeName下所有节点
        public void deleteAllNode(string xmlFilePath, string rootNodeName)
        {
            XmlDocument xd = new XmlDocument();
            xd.Load(xmlFilePath);
            XmlNode xn = xd.SelectSingleNode(rootNodeName);
            xn.RemoveAll();
            xd.Save(xmlFilePath);
                
        }
        //搜索某一date属性的节点
        public storeFur searchSingleNode(string xmlFilePath, string rootNodeName,string str_single)
        {
            storeFur stf = new storeFur();
            XmlDocument xd = new XmlDocument();
            xd.Load(xmlFilePath);
            XmlNode xn = xd.SelectSingleNode(rootNodeName);
            XmlNodeList xl = xn.ChildNodes;
            foreach (XmlNode xxn in xl)
            {
                if (xxn.Attributes[0].Value.ToString() == str_single)
                {
                    string[] str = { xxn.ChildNodes[0].InnerText, xxn.ChildNodes[1].InnerText, xxn.ChildNodes[2].InnerText, xxn.ChildNodes[3].InnerText, xxn.ChildNodes[4].InnerText, xxn.ChildNodes[5].InnerText };
                    stf.SetV(str);
                }
            
            }
            return stf;
        }
        //删除某一date属性的节点
        public void deleteSingleNode(string xmlFilePath, string rootNodeName, string str_single)
        {
          
            XmlDocument xd = new XmlDocument();
            xd.Load(xmlFilePath);
            XmlNode xn = xd.SelectSingleNode(rootNodeName);
            XmlNodeList xl = xn.ChildNodes;
            foreach (XmlNode xxn in xl)
            {
                if (xxn.Attributes[0].Value.ToString() == str_single)
                {
                    xn.RemoveChild(xxn);
                   
                }

            }
            xd.Save(xmlFilePath);
        }
      
        /// <summary>
        //更新某一节点
        /// </summary>
        /// <param name="xmlFilePath">文件路径</param>
        /// <param name="rootNodename">根节点名字</param>
        /// <param name="str_single">节点attribute值</param>
        /// <param name="stf">欲替代的storeFur值</param>
        public void updateSingleNode(string xmlFilePath, string rootNodeName, string str_single,storeFur stf)
        {
            deleteSingleNode(xmlFilePath, rootNodeName, str_single);
            AddFurElement(xmlFilePath, stf, rootNodeName);
        }
        //更新某一节点
        /// <summary>
        /// 增加第一层的节点
        /// </summary>
        /// <param name="xmlFilePath">文件路径</param>
        /// <param name="RootPath">根节点名字</param>
        /// <param name="Name">所要添加第一层节点的节点名</param>
        /// <param name="attribute"></param>
        public void AddXmlFirstNode(string xmlFilePath, string RootPath, string Name, string[,] attribute)
        {
            try
            {
                XmlDocument myXmlDoc = new XmlDocument();
                myXmlDoc.Load(xmlFilePath);

                XmlNode memberlist = myXmlDoc.SelectSingleNode(RootPath);
                //XmlNodeList nodelist = memberlist.ChildNodes;

                XmlElement firstLevelElement1 = myXmlDoc.CreateElement(Name);
                //填充第一层的第一个子节点的属性值（SetAttribute）
                for (int i = 0; i < attribute.GetLength(0); i++)
                {
                    firstLevelElement1.SetAttribute(attribute[i, 0], attribute[i, 1]);
                }
                //将第一层的第一个子节点加入到根节点下
                memberlist.AppendChild(firstLevelElement1);

                //保存更改
                myXmlDoc.Save(xmlFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// 增加第二层节点
        /// </summary>
        /// <param name="xmlFilePath">路径</param>
        /// <param name="RootPath">根节点名</param>
        /// <param name="FirstElementattributesName">第一层节点+属性名</param>
        /// <param name="Firstattributes">第一层节点属性名对应的值</param>
        /// <param name="SecondElement">所要增加的第二层节点名</param>
        /// <param name="SecondinnerText">第二层节点对应的存储内容</param>
        public void AddXmlSecondNod(string xmlFilePath, string RootPath, string FirstElementattributesName, string Firstattributes, string[] SecondElement, string[] SecondinnerText)
        {
            try
            {
                XmlDocument myXmlDoc = new XmlDocument();
                myXmlDoc.Load(xmlFilePath);

                XmlNode memberlist = myXmlDoc.SelectSingleNode(RootPath);
                XmlNodeList nodelist = memberlist.ChildNodes;

                //添加一个带有属性的节点信息
                foreach (XmlNode node in nodelist)
                {
                    
                    if (node.Attributes[FirstElementattributesName].Value.Equals(Firstattributes))
                    {
                        for (int i = 0; i < SecondElement.Length; i++)
                        {
                            XmlElement newElement = myXmlDoc.CreateElement(SecondElement[i]);
                            newElement.InnerText = SecondinnerText[i];
                            node.AppendChild(newElement);
                        }
                    }
                }
                //保存更改
                myXmlDoc.Save(xmlFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        /// <summary>
        /// 获取第一层节点的属性值，返回所有的属性名和对应的值
        /// </summary>
        /// <param name="xmlFilePath">文件路径</param>
        /// <param name="RootPath">根节点名</param>
        /// <param name="firstNodeName">第一层节点名</param>
        /// <returns></returns>
        public ArrayList GetXMLFirstNodeAttributes(string xmlFilePath, string RootPath, string firstNodeName)
        {
            ArrayList list = new ArrayList();
            try
            {
                //初始化一个xml实例
                XmlDocument myXmlDoc = new XmlDocument();
                //加载xml文件（参数为xml文件的路径）
                myXmlDoc.Load(xmlFilePath);
                //获得第一个姓名匹配的节点（SelectSingleNode）：此xml文件的根节点
                XmlNode rootNode = myXmlDoc.SelectSingleNode(RootPath);
                //分别获得该节点的InnerXml和OuterXml信息
                string innerXmlInfo = rootNode.InnerXml.ToString();
                string outerXmlInfo = rootNode.OuterXml.ToString();
                //获得该节点的子节点（即：该节点的第一层子节点）
                XmlNodeList firstLevelNodeList = rootNode.ChildNodes;
                foreach (XmlNode node in firstLevelNodeList)
                {
                    //获得该节点的属性集合
                    if (node.Name == firstNodeName)
                    {
                        XmlAttributeCollection attributeCol = node.Attributes;
                        foreach (XmlAttribute attri in attributeCol)
                        {
                            //获取属性名称与属性值
                            string name = attri.Name;
                            string value = attri.Value;
                            list.Add(name + ":" + value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return list;
        }


        /// <summary>
        /// 获取第二层节点的存储值
        /// </summary>
        /// <param name="xmlFilePath">文件路径</param>
        /// <param name="RootPath">根节点</param>
        /// <param name="firstNodeName">第一层节点名</param>
        /// <param name="secondNoadeName">第二层节点名</param>
        /// <returns></returns>
        public ArrayList GetXMLSecondNodeValue(string xmlFilePath, string RootPath, string firstNodeName, string secondNoadeName)
        {
            ArrayList list = new ArrayList();
            try
            {
                //初始化一个xml实例
                XmlDocument myXmlDoc = new XmlDocument();
                //加载xml文件（参数为xml文件的路径）
                myXmlDoc.Load(xmlFilePath);
                //获得第一个姓名匹配的节点（SelectSingleNode）：此xml文件的根节点
                XmlNode rootNode = myXmlDoc.SelectSingleNode(RootPath);
                //分别获得该节点的InnerXml和OuterXml信息
                string innerXmlInfo = rootNode.InnerXml.ToString();
                string outerXmlInfo = rootNode.OuterXml.ToString();
                //获得该节点的子节点（即：该节点的第一层子节点）
                XmlNodeList firstLevelNodeList = rootNode.ChildNodes;
                foreach (XmlNode node in firstLevelNodeList)
                {
                    //获得该节点的属性集合
                    if (node.Name == firstNodeName)
                    {
                        foreach (XmlNode _node in node.ChildNodes)
                        {
                            if (_node.Name == secondNoadeName)
                                list.Add(_node.InnerText);
                        }
                    }

                    //判断此节点是否还有子节点
                    if (node.HasChildNodes)
                    {
                        //获取该节点的第一个子节点
                        XmlNode secondLevelNode1 = node.FirstChild;
                        //获取该节点的名字
                        string name = secondLevelNode1.Name;
                        //获取该节点的值（即：InnerText）
                        string innerText = secondLevelNode1.InnerText;
                        Console.WriteLine("{0} = {1}", name, innerText);

                        //获取该节点的第二个子节点（用数组下标获取）
                        XmlNode secondLevelNode2 = node.ChildNodes[1];
                        name = secondLevelNode2.Name;
                        innerText = secondLevelNode2.InnerText;
                        Console.WriteLine("{0} = {1}", name, innerText);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return list;
        }

        //自定义函数获取第二层节点的所有存储值
        public ArrayList GetAllXMLSecondNodeValue(string xmlFilePath, string RootPath, string firstNodeName)
        {
            ArrayList list = new ArrayList();
            try
            {
                //初始化一个xml实例
                XmlDocument myXmlDoc = new XmlDocument();
                //加载xml文件（参数为xml文件的路径）
                myXmlDoc.Load(xmlFilePath);
                //获得第一个姓名匹配的节点（SelectSingleNode）：此xml文件的根节点
                XmlNode rootNode = myXmlDoc.SelectSingleNode(RootPath);
                //分别获得该节点的InnerXml和OuterXml信息
                string innerXmlInfo = rootNode.InnerXml.ToString();
                string outerXmlInfo = rootNode.OuterXml.ToString();
                //获得该节点的子节点（即：该节点的第一层子节点）
                XmlNodeList firstLevelNodeList = rootNode.ChildNodes;
                foreach (XmlNode node in firstLevelNodeList)
                {
                    //获得该节点的属性集合
                    if (node.Name == firstNodeName)
                    {
                        foreach (XmlNode _node in node.ChildNodes)
                        {
                            
                                list.Add(_node.InnerText);
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return list;
        }

        /// <summary>
        /// 修改第一层节点的属性值
        /// </summary>
        /// <param name="xmlFilePath">文件路径</param>
        /// <param name="RootPath">根节点名</param>
        /// <param name="FirstNodeName">第一节点名</param>
        /// <param name="FirstNodeAttributes">第一节点属性名</param>
        /// <param name="FirstNodeAttributesOldValue">第一节点属性值</param>
        /// <param name="newValue"></param>
        public void ModifyXmlFirstattribute(string xmlFilePath, string RootPath, string FirstNodeName, string FirstNodeAttributes, string FirstNodeAttributesOldValue, string newValue)
        {
            try
            {
                XmlDocument myXmlDoc = new XmlDocument();
                myXmlDoc.Load(xmlFilePath);
                //XmlNode rootNode = myXmlDoc.FirstChild;
                //XmlNodeList firstLevelNodeList = rootNode.ChildNodes;
                XmlNode rootNode = myXmlDoc.SelectSingleNode(RootPath);
                foreach (XmlNode node in rootNode.ChildNodes)
                {
                    if (node.Name.Equals(FirstNodeName))
                    {
                        //修改此节点的属性值
                        if (node.Attributes[FirstNodeAttributes].Value.Equals(FirstNodeAttributesOldValue))
                        {
                            node.Attributes[FirstNodeAttributes].Value = newValue;
                        }
                    }
                }
                //要想使对xml文件所做的修改生效，必须执行以下Save方法
                myXmlDoc.Save(xmlFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        /// <summary>
        /// 修改第二节点的存储值
        /// </summary>
        /// <param name="xmlFilePath">文件路径</param>
        /// <param name="RootPath">根节点名字</param>
        /// <param name="FirstNodeName">第一节点名字</param>
        /// <param name="FirstNodeAttributes">第一节点属性名</param>
        /// <param name="FirstNodeAttributesValue">第一节点属性值</param>
        /// <param name="SecondNodeName">第二节点名字</param>
        /// <param name="value">第二节点存储值</param>
        public void ModifyXmlElementValue(string xmlFilePath, string RootPath, string FirstNodeName, string FirstNodeAttributes, string FirstNodeAttributesValue, string SecondNodeName, string value)
        {
            try
            {
                XmlDocument myXmlDoc = new XmlDocument();
                myXmlDoc.Load(xmlFilePath);
                XmlNode rootNode = myXmlDoc.SelectSingleNode(RootPath);
                foreach (XmlNode node in rootNode.ChildNodes)
                {
                    if (node.Name.Equals(FirstNodeName))
                    {
                        //修改此节点的属性值
                        if (node.Attributes[FirstNodeAttributes].Value.Equals(FirstNodeAttributesValue))
                        {
                            foreach (XmlNode _node in node.ChildNodes)
                            {
                                if (_node.Name == SecondNodeName)
                                {
                                    _node.InnerText = value;
                                }
                            }
                        }
                    }
                }
                //要想使对xml文件所做的修改生效，必须执行以下Save方法
                myXmlDoc.Save(xmlFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }



        /// <summary>
        /// 删除第一节点
        /// </summary>
        /// <param name="xmlFilePath">路径</param>
        /// <param name="RootPath">根节点</param>
        /// <param name="FirstNodeName">第一节点名</param>
        /// <param name="FirstNodeAttributes">第一节点属性名</param>
        /// <param name="FirstNodeAttributesValue">第一节点属性值</param>
        public void DeleteXmlFirstnode(string xmlFilePath, string RootPath, string FirstNodeName, string FirstNodeAttributes, string FirstNodeAttributesValue)
        {
            try
            {
                XmlDocument myXmlDoc = new XmlDocument();
                myXmlDoc.Load(xmlFilePath);
                XmlNode rootNode = myXmlDoc.SelectSingleNode(RootPath);

                foreach (XmlNode node in rootNode.ChildNodes)
                {
                    if (node.Name.Equals(FirstNodeName))
                    {
                        if (node.Attributes[FirstNodeAttributes].Value.Equals(FirstNodeAttributesValue))
                        {
                            //node.RemoveAll();
                            rootNode.RemoveChild(node);
                        }
                    }
                }
                //保存对xml文件所做的修改
                myXmlDoc.Save(xmlFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// 删除子节点
        /// </summary>
        /// <param name="xmlFilePath">路径</param>
        /// <param name="FirstElementattributesName">第一节点属性名</param>
        /// <param name="Firstattributes">第一节点属性值</param>
        /// <param name="secondnodeName">子节点名称</param>
        public void DeleteXmlsecondNode(string xmlFilePath, string RootPath, string FirstNodeName, string FirstNodeAttributes, string FirstNodeAttributesValue, string secondnodeName)
        {
            try
            {
                XmlDocument myXmlDoc = new XmlDocument();
                myXmlDoc.Load(xmlFilePath);
                XmlNode rootNode = myXmlDoc.SelectSingleNode(RootPath);

                foreach (XmlNode node in rootNode.ChildNodes)
                {
                    if (node.Name.Equals(FirstNodeName))
                    {
                        if (node.Attributes[FirstNodeAttributes].Value.Equals(FirstNodeAttributesValue))
                        {
                            foreach (XmlNode _node in node.ChildNodes)
                            {
                                if (_node.Name == secondnodeName)
                                    //_node.RemoveAll();
                                    node.RemoveChild(_node);

                            }
                        }
                    }
                }
                //保存对xml文件所做的修改
                myXmlDoc.Save(xmlFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


    }
    public class storeFur
    {
        public
            string variety, number, inprice, onprice, outprice, date;
        public
        storeFur(string[] value)
        {
            if (value.Length == 6)
            {
                variety = value[0];
                number = value[1];
                inprice = value[2];
                onprice = value[3];
                outprice = value[4];
                date = value[5];               
            }
            
        }
        public
        storeFur()
        {
        }
        public
            string[] GetV()
        {
            string[] value = new string[6];
            value[0] = variety;
            value[1] = number;
            value[2] = inprice;
            value[3] = onprice;
            value[4] = outprice;
            value[5] = date;
            return value;

        }
        public
        bool SetV(string[] value)
        {
            if (value.Length == 6)
            {
                variety = value[0];
                number = value[1];
                inprice = value[2];
                onprice = value[3];
                outprice = value[4];
                date = value[5];
                return true;
            }
            else
            return false;
        }
    }

    }



