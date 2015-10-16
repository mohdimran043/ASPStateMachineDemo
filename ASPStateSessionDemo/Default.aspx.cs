using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Utilities;

namespace ASPStateSessionDemo
{
    public partial class _Default : Page
    {
        public DataTable ds
        {
            get
            {
                if (null != Session["MyTable"])
                {
                    DataTable dt = (DataTable)JsonConvert.DeserializeObject(Session["MyTable"].ToString(), (typeof(DataTable)));
                    return dt;
                }
                else
                    return null;

            }
            set
            {
                Session["MyTable"] = JsonConvert.SerializeObject(value);
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                CreateTable();

                DataTable myDT = ds;
            }
            catch (Exception ex)
            {
                
                throw;
            }
           
        }

        private void CreateTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Age");

            DataRow dr = dt.NewRow();
            dr["Name"] = "Imran";
            dr["Age"] = "27";

            dt.Rows.Add(dr);

            ds = dt;


        }
    }
}