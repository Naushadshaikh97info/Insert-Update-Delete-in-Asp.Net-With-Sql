using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    string cs = System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        fill_data();
    }
    private void fill_data()
    {
        SqlConnection con = new SqlConnection(cs);
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT TOP 10 intglcode,firstname, lastname, emailid, mobileno FROM registraion_mst", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        else
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            GridView1.DataSource = ds;
            GridView1.DataBind();
            int columncount = GridView1.Rows[0].Cells.Count;
            GridView1.Rows[0].Cells.Clear();
            GridView1.Rows[0].Cells.Add(new TableCell());
            GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
            GridView1.Rows[0].Cells[0].Text = "No Records Found";
        }
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(cs);

        SqlCommand cmd = new SqlCommand("INSERT INTO registraion_mst (firstname,lastname,emailid,mobileno) VALUES('" + txt_firstname.Text + "','" + txt_lastname.Text + "','" + txt_emailid.Text + "','" + txt_mobileno.Text + "')", con);

        con.Open();

        cmd.ExecuteNonQuery();

        con.Close();

        fill_data();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fill_data();
    }
    protected void btn_update_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(cs);

        SqlCommand cmd = new SqlCommand("Update tbl_Employee set firstname='" + txt_firstname.Text + "',lastname='" + txt_lastname.Text + "',emailid='" + txt_emailid.Text + "',mobileno='" + txt_mobileno.Text + "'  where ID='" + Convert.ToInt32(ViewState["id"]) + "'", con);

        con.Open();

        cmd.ExecuteNonQuery();

        con.Close();

        fill_data();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int usrid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
        SqlConnection con = new SqlConnection(cs);
        con.Open();
        SqlCommand cmd = new SqlCommand("delete from registraion_mst where intglcode=" + usrid, con);
        cmd.ExecuteNonQuery();
        con.Close();
        fill_data();
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;

        GridViewRow grow = btn.NamingContainer as GridViewRow;

        //hidCustomerID.Value = (grow.FindControl("lblCustomerID") as Label).Text;

        txt_firstname.Text = (grow.FindControl("firstname") as Label).Text;

        txt_lastname.Text = (grow.FindControl("lastname") as Label).Text;

        txt_emailid.Text = (grow.FindControl("emailid") as Label).Text;

        txt_mobileno.Text = (grow.FindControl("mobileno") as Label).Text;

        //btnSave.Visible = false;

        //btnUpdate.Visible = true;
    }
}