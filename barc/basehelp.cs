using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Xml;
using System.Runtime.Serialization.Json;
using System.Collections;

using System.Runtime.Serialization;
using System.Data.OleDb;
using System.Data;
using barc.barcodeDataSetTableAdapters;
using System.Reflection;
using System.Threading;

namespace barc
{
    [DataContract]
    class Codetable {
        [DataMember]
        public string table { get; set; }
         [DataMember]
        public string code { get;set; }
         [DataMember]
        public string name{get;set;}
         [DataMember]
         public string memo { get; set; }
    }
    
     class basehelp

    {
         String[] tables = { "BC_PRODUCT","bc_type1","bc_type2","bc_type3","bc_type4","bc_oem",
                               "bc_factory","bc_class","bc_gonglv","bc_color", "BC_ELECFLOW", 
                               "bc_ctype","bc_memo" };
         List<Hashtable> ls = new List<Hashtable>();

         private OleDbConnection conn; 
         private OleDbDataAdapter oda = new OleDbDataAdapter(); 
         private DataSet myds = new DataSet();
         String IP = Properties.Settings.Default.ip;
         
        public basehelp() {
            Console.WriteLine("启动同步线程");
            }

       

        //反序列化  

        public  T FromJsonTo<T>(string jsonString)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
            {
                T jsonObject = (T)ser.ReadObject(ms);
                return jsonObject;
            }
        }

    

        public void uprun() {
          Console.WriteLine("开始上传条码数据");
          barcodeDataSetTableAdapters.BC_BARCODETableAdapter bc_barcodeTableAdapter = new barcodeDataSetTableAdapters.BC_BARCODETableAdapter();
         
          barcodeDataSet.BC_BARCODEDataTable barcodetable = bc_barcodeTableAdapter.GetData();

          for (int i = 0; i < barcodetable.Rows.Count; i++) {
              String s = JsonConvert(barcodetable.Rows[i]);
              try
              {
                  WebClient client = new WebClient();
                  client.Encoding = System.Text.Encoding.UTF8;
                  string backstr = client.DownloadString(new Uri("http://"+IP+":8888/iims/CodeServlet.svt?method=up&data=" + s));
                  if (backstr.Equals("ok"))
                  {
                      bc_barcodeTableAdapter.DeleteQuery(int.Parse(barcodetable.Rows[i]["id"].ToString()));
                      //bc_barcodeTableAdapter.UpdateIsa(true, int.Parse(barcodetable.Rows[i]["id"].ToString()));
                      Console.WriteLine(barcodetable.Rows[i]["id"].ToString());
                     
                  }             
              }
              catch (Exception e) {
                  Console.WriteLine(e.Message);
              }
          
          }
        
            
        }




        public string JsonConvert(DataRow ds)
        {
           
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            for (int j = 0; j < ds.Table.Columns.Count; j++)
                {
                    sb.Append("");
                    sb.Append(ds.Table.Columns[j].ColumnName);
                    sb.Append(":\"");
                    sb.Append(ds[j].ToString().Trim());
                    sb.Append("\",");
                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append("},");
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }



        public void run() {
            conn = new OleDbConnection();
            conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\barcode.accdb";
            conn.Open();
            while (true)
            {
                Console.WriteLine("同步数据");
                //同步数据
                foreach (String s in tables)
                {
                    try
                    {
                        WebClient client = new WebClient();
                        client.Encoding = System.Text.Encoding.UTF8;
                        client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_downloadstringcomplete);
                        // string S = client.DownloadString(new Uri("http://chen-pc:8888/iims/CodeServlet.svt?method=query&tablename=" + s));
                        client.DownloadStringAsync(new Uri("http://"+IP+":8888/iims/CodeServlet.svt?method=query&tablename=" + s));
                        //client_downloadstringcomplete(S);
                    }
                    catch (WebException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                Thread.Sleep(Properties.Settings.Default.re_time* 60 * 1000);
            }
           
           
        }

     
        private void client_downloadstringcomplete(object sender, DownloadStringCompletedEventArgs e)
        {
            try{
                client_downloadstringcomplete(e.Result);
            }catch(Exception ex){
                 Console.WriteLine(ex.Message);
            }
               
         }

        private void client_downloadstringcomplete(string s)
        {
            try
            {
                List<Codetable> obj = FromJsonTo<List<barc.Codetable>>(s);
                for (int i = 0; i < obj.Count; i++)
                {
                    Codetable item = obj[i];
                    if (i == 0)
                    {
                        OleDbCommand sqldcmd = new OleDbCommand("delete from " + item.table, conn);
                        sqldcmd.ExecuteNonQuery();
                    }


                    StringBuilder sql = new StringBuilder("insert into ");
                    sql.Append(item.table);
                    sql.Append("(code,name) values (");
                    sql.Append("'" + item.code + "'");
                    sql.Append(",");
                    sql.Append("'" + item.name + "'");
                    sql.Append(")");
                    Console.WriteLine(sql.ToString());
                    OleDbCommand sqlcmd = new OleDbCommand(sql.ToString(), conn);
                    sqlcmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

            
        }

        
    }


