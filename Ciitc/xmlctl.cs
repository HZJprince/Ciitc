using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Ciitc
{
    class xmlctl
    {
        public bool xml(string xmltext,int count,BackgroundWorker bk,int radio)
        {
            int total = 0;
            try
            {
                XElement xmldoc = XElement.Load(xmltext);
                total = Convert.ToInt32(xmldoc.Element("HEAD").Elements().ElementAt(1).Value);
                foreach (XElement dataElem in xmldoc.Element("DATA").Elements())
                {
                    if (dataElem.Value.ToString() == "")
                    {
                        continue;
                    }
                    else if (radio == 1)
                    {
                        foreach (XElement packetElem in dataElem.Elements())
                        {
                            var districtNode = packetElem.Element("DISTRICT_CODE").Value;
                            var companyNode = packetElem.Element("COMPANY_CODE").Value;
                            var querysqNode = packetElem.Element("QUERY_SEQUENCE_NO").Value;
                            var querydateNode = packetElem.Element("QUERY_DATE").Value;
                            var billdateNode = packetElem.Element("BILL_DATE").Value;
                            var startdateNode = packetElem.Element("START_DATE").Value;
                            var enddateNode = packetElem.Element("END_DATE").Value;
                            var licensetpNode = packetElem.Element("LICENSE_TYPE").Value;
                            var motortpNode = packetElem.Element("MOTOR_TYPE_CODE").Value;
                            var usenatureNode = packetElem.Element("USE_NATURE_CODE").Value;
                            var licensenoNode = packetElem.Element("LICENSE_NO").Value;
                            var framenoNode = packetElem.Element("FRAME_NO").Value;
                            var enginenoNode = packetElem.Element("ENGINE_NO").Value;
                            var premiumNode = packetElem.Element("PREMIUM").Value;

                            string sql = "insert into CX values(@DISTRICT_CODE,@COMPANY_CODE,@QUERY_SEQUENCE_NO,@QUERY_DATE,@BILL_DATE," +
                                         "@START_DATE,@END_DATE,@LICENSE_TYPE,@MOTOR_TYPE_CODE,@USE_NATURE_CODE,@LICENSE_NO" +
                                         ",@FRAME_NO,@ENGINE_NO,@PREMIUM)";
                            SQLHelper sqlh = new SQLHelper();
                            int status = sqlh.ExecuteNonQuery(sql, new SqlParameter("@DISTRICT_CODE", districtNode), new SqlParameter("@COMPANY_CODE", companyNode),
                                new SqlParameter("@QUERY_SEQUENCE_NO", querysqNode), new SqlParameter("@QUERY_DATE", querydateNode),
                                new SqlParameter("@BILL_DATE", billdateNode), new SqlParameter("@START_DATE", startdateNode),
                                new SqlParameter("@END_DATE", enddateNode), new SqlParameter("@LICENSE_TYPE", licensetpNode),
                                new SqlParameter("@MOTOR_TYPE_CODE", motortpNode), new SqlParameter("@USE_NATURE_CODE", usenatureNode),
                                new SqlParameter("@LICENSE_NO", licensenoNode), new SqlParameter("@FRAME_NO", framenoNode),
                                new SqlParameter("@ENGINE_NO", enginenoNode), new SqlParameter("@PREMIUM", premiumNode));
                            count = count + status;
                            int precent = (int)(((double)count / (double)total) * 100);
                            bk.ReportProgress(precent);
                        }
                    }
                    else if (radio == 0)
                    {
                        foreach (XElement packetElem in dataElem.Elements())
                        {
                            var districtNode = packetElem.Element("DISTRICT_CODE").Value;
                            var companyNode = packetElem.Element("COMPANY_CODE").Value;
                            var policynoNode = packetElem.Element("POLICY_NO").Value;
                            var querysqNode = packetElem.Element("QUERY_SEQUENCE_NO").Value;
                            var confirmnoNode = packetElem.Element("CONFIRMSEQUENCE_NO").Value;
                            var confirmdateNode = packetElem.Element("CONFIRM_DATE").Value;
                            var billdateNode = packetElem.Element("BILL_DATE").Value;
                            var startdateNode = packetElem.Element("START_DATE").Value;
                            var enddateNode = packetElem.Element("END_DATE").Value;
                            var licensetpNode = packetElem.Element("LICENSE_TYPE").Value;
                            var motortpNode = packetElem.Element("MOTOR_TYPE_CODE").Value;
                            var usenatureNode = packetElem.Element("USE_NATURE_CODE").Value;
                            var licensenoNode = packetElem.Element("LICENSE_NO").Value;
                            var framenoNode = packetElem.Element("FRAME_NO").Value;
                            var enginenoNode = packetElem.Element("ENGINE_NO").Value;
                            var premiumNode = packetElem.Element("PREMIUM").Value;

                            string sql = "insert into QD values(@DISTRICT_CODE,@COMPANY_CODE,@POLICY_NO,@QUERY_SEQUENCE_NO,@CONFIRMSEQUENCE_NO,@CONFIRM_DATE,@BILL_DATE," +
                                         "@START_DATE,@END_DATE,@LICENSE_TYPE,@MOTOR_TYPE_CODE,@USE_NATURE_CODE,@LICENSE_NO" +
                                         ",@FRAME_NO,@ENGINE_NO,@PREMIUM)";
                            SQLHelper sqlh = new SQLHelper();
                            int status = sqlh.ExecuteNonQuery(sql, new SqlParameter("@DISTRICT_CODE", districtNode), new SqlParameter("@COMPANY_CODE", companyNode),
                                new SqlParameter("@POLICY_NO", policynoNode), new SqlParameter("@QUERY_SEQUENCE_NO", querysqNode),
                                new SqlParameter("@CONFIRMSEQUENCE_NO", confirmnoNode), new SqlParameter("@CONFIRM_DATE", confirmdateNode),
                                new SqlParameter("@BILL_DATE", billdateNode), new SqlParameter("@START_DATE", startdateNode),
                                new SqlParameter("@END_DATE", enddateNode), new SqlParameter("@LICENSE_TYPE", licensetpNode),
                                new SqlParameter("@MOTOR_TYPE_CODE", motortpNode), new SqlParameter("@USE_NATURE_CODE", usenatureNode),
                                new SqlParameter("@LICENSE_NO", licensenoNode), new SqlParameter("@FRAME_NO", framenoNode),
                                new SqlParameter("@ENGINE_NO", enginenoNode), new SqlParameter("@PREMIUM", premiumNode));
                            count = count + status;
                            int precent = (int)(((double)count / (double)total) * 100);
                            bk.ReportProgress(precent);
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public bool yml(int radio)
        {
            string sql = "";
            try
            {
                if (radio == 1)
                {
                    sql = "delete from CX";
                }
                else if (radio == 0)
                {
                    sql = "delete from QD";
                }
                SQLHelper sqlh = new SQLHelper();
                sqlh.ExecuteNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
