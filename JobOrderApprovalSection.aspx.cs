using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class JobOrderApprovalSection : System.Web.UI.Page
{
    SqLDataAccess objSqLDataAccess = new SqLDataAccess();
    baseProperties bsProperty = new baseProperties();
    BindList objBindList = new BindList();
    ListItem objListItem = new ListItem("---Select---", "0");
    ListItem objListItem1 = new ListItem("---Select---", "0");
    ListItem objListItem2 = new ListItem("---Select---", "0");
    ListItem objListItem3 = new ListItem("---Select---", "0");
    ListItem objListItem4 = new ListItem("---Select---", "0");
    ListItem objListItem5 = new ListItem("---Select---", "0");
    ListItem objListItem6 = new ListItem("---Select---", "0");
    ListItem objListItem7 = new ListItem("---Select---", "0");
    ListItem objListItem8 = new ListItem("---Select---", "0");
    string strAppLevel;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
             SqlDataReader rd = objSqLDataAccess.GetJobDetail(Convert.ToString(Request.QueryString["ID"])) as SqlDataReader;
             while (rd.Read())
             {
                 HiddenField1.Value = "";
                 //ddlRequesterName.Visible = false;
                 //txtWorkOrder.Text = Convert.ToString(rd["WorkOrderNo"]);
                 //dtWorkDate.SelectedDate = Convert.ToDateTime(rd["WorkOrderDate"]);
                 //txtResident.Text = Convert.ToString(rd["RequesterID"]);
                 //txtUnit.Text = Convert.ToString(rd["UnitNo"]);
                 //txtMobileNo.Text = Convert.ToString(rd["MobileNumber"]);
                 lblType.Text = Convert.ToString(rd["OrderCase"]);
                 lblDept.Text = Convert.ToString(rd["FaultTypeName"]);
                 //ddlPriority.SelectedValue = Convert.ToString(rd["Priority"]);
                 //if (Convert.ToString(rd["DeadlineDate"]) != "1/1/1900 12:00:00 AM")
                 //{
                 //    dtTimeDemand.SelectedDate = Convert.ToDateTime(rd["DeadlineDate"]);
                 //}
                 //ddlPriority.SelectedValue = Convert.ToString(rd["Priority"]);
                 //ddlFaultLocation.SelectedValue = Convert.ToString(rd["Location"]);
                 //ddlWorkType.SelectedValue = Convert.ToString(rd["FaultType"]);
                 //txtDescription.Text = Convert.ToString(rd["Description"]);
                 //ImgPic.Src = "~/FaultImages/" + Convert.ToString(rd["ImagePath"]);
                 //ddlLCategory.SelectedValue = Convert.ToString(rd["LType"]);
                 lblLastActionDate.Text = Convert.ToString(rd["LastActionDate"]);
                 txtRoomNo1.Text = Convert.ToString(rd["RoomNo"]);
                 txtContactPerson1.Text = Convert.ToString(rd["ContactPerson"]);
                 HiddenField1.Value = Convert.ToString(rd["ApprLevel"]);
                 //txtApprovedDesc.Text = Convert.ToString(rd["AppDesc"]);
                 txtMConnents.Text = Convert.ToString(rd["Description"]);
                 lblPriority.Text = Convert.ToString(rd["PriorityName"]);
                 txtMworkOrder.Text = Convert.ToString(rd["WorkOrderNo"]);
                 ddlMPriority.SelectedValue = Convert.ToString(rd["Priority"]);
                 dtWorkOrderNo.SelectedDate = Convert.ToDateTime(rd["WorkOrderDate"]);
                 txtMCategory.Text = Convert.ToString(rd["MCategory"]); ;
                 ddlWorkType1.SelectedValue = Convert.ToString(rd["FaultType"]);
                 txtMLocation.Text = Convert.ToString(rd["LocationName"]);
                 ddlApprovedStatus.SelectedValue = Convert.ToString(rd["Status"]);
                 txtReply.Text = Convert.ToString(rd["RejectedComments"]);
                 txtJobOrder.Text = txtMworkOrder.Text;
                 txtCategory1.Text = txtMCategory.Text;
                 lblDepartment.Text = lblDept.Text;
                //txtDes1.Text = txtDescription.Text;
                 lblLastAction.Text = Convert.ToString(rd["LastActionTakenBy"]);
                 lblLast.Text = Convert.ToString(rd["LastActionTakenBy"]);
                 lblAssests.Text = Convert.ToString(rd["EquipmentCode"]);
                 txtEquip.Text = Convert.ToString(rd["EquipmentCode"]);
                txtELocation.Text = Convert.ToString(rd["EMainlocation"]);
                // txtRoomNo1.Text = txtRoomNo.Text;
                 //txtContactPerson1.Text = txtContactPerson.Text;
             }
             DataTable dt1 = objSqLDataAccess.GetBindListById(DBSQL.GET_JOB_ORDER_ITEM_BYID, txtMworkOrder.Text);
             gvMaterial.DataSource = dt1;
             gvMaterial.DataBind();
             DataTable dtCom = objSqLDataAccess.GetBindListById(DBSQL.GET_JOB_COMMENTS_BYJOB, txtMworkOrder.Text);
             gvComments.DataSource = dtCom;
             gvComments.DataBind();

             objBindList.BindDropDownList(ddlUser, DBSQL.GET_USER_FORWRDED1, "ID", "EName");
             ddlUser.Items.Insert(0, objListItem8);

             DataTable dtUser = objSqLDataAccess.GetBindList(DBSQL.GET_USER_FORWRDED1);

             chkUser.DataSource = dtUser;
             chkUser.DataTextField = "EName";
             chkUser.DataValueField = "ID";
             chkUser.DataBind();

             string strUser = Convert.ToString(Session["UserTypeID"]);
             if (strUser == "4" && HiddenField1.Value == "0")
             {
                 //bsProperty.OPerationManager = Convert.ToString(Session["EName"]);
                 //bsProperty.OPerationManagerDate = Convert.ToString(DateTime.Now);
                 ddlApprovedStatus.Enabled = true;
                 txtApprovedDesc.Enabled = true;
                 btnSave.Enabled = true;
             }

             if (strUser == "3" && HiddenField1.Value == "0")
             {
                 //bsProperty.OPerationManager = Convert.ToString(Session["EName"]);
                 //bsProperty.OPerationManagerDate = Convert.ToString(DateTime.Now);
                 ddlApprovedStatus.Enabled = false;
                 txtApprovedDesc.Enabled = false;
                 btnSave.Enabled = false;

                 //ddlApprovedStatus
             }
             else if (strUser == "6" && HiddenField1.Value == "1")
             {
                 //bsProperty.OPerationManager = Convert.ToString(Session["EName"]);
                 //bsProperty.OPerationManagerDate = Convert.ToString(DateTime.Now);
                 ddlApprovedStatus.Enabled = true;
                 txtApprovedDesc.Enabled = true;
                 btnSave.Enabled = true;
             }
             else if (strUser == "7" && HiddenField1.Value == "2")
             {
                 //bsProperty.OPerationManager = Convert.ToString(Session["EName"]);
                 //bsProperty.OPerationManagerDate = Convert.ToString(DateTime.Now);
                 ddlApprovedStatus.Enabled = true;
                 txtApprovedDesc.Enabled = true;
                 btnSave.Enabled = true;
             }

             //else if (strUser == "12" && HiddenField1.Value == "3")
             //{
             //    //bsProperty.OPerationManager = Convert.ToString(Session["EName"]);
             //    //bsProperty.OPerationManagerDate = Convert.ToString(DateTime.Now);
             //    ddlApprovedStatus.Enabled = true;
             //    txtApprovedDesc.Enabled = true;
             //    btnSave.Enabled = true;
             //}

             else if (strUser == "8" && HiddenField1.Value == "3")
             {
                 //bsProperty.OPerationManager = Convert.ToString(Session["EName"]);
                 //bsProperty.OPerationManagerDate = Convert.ToString(DateTime.Now);
                 ddlApprovedStatus.Enabled = true;
                 txtApprovedDesc.Enabled = true;
                 btnSave.Enabled = true;
             }
             else if (strUser == "9" && HiddenField1.Value == "4")
             {
                 //bsProperty.OPerationManager = Convert.ToString(Session["EName"]);
                 //bsProperty.OPerationManagerDate = Convert.ToString(DateTime.Now);
                 ddlApprovedStatus.Enabled = true;
                 txtApprovedDesc.Enabled = true;
                 btnSave.Enabled = true;
             }

             //if (ddlLCategory.SelectedValue == "2")
             //{
             //    tr1.Visible = true;
             //    tr2.Visible = true;
             //    tr3.Visible = true;
             //    ddlFaultLocation.Enabled = false;
             //    //trL1.Visible = false;
             //}
             //else if (ddlLCategory.SelectedValue == "1")
             //{
             //    //trL1.Visible = true;
             //    ddlFaultLocation.Enabled = true;
             //    tr1.Visible = false;
             //    tr2.Visible = false;
             //    tr3.Visible = false;
             //    //objBindList.BindDropDownListByID(ddlFaultLocation, DBSQL.GET_LOCAATION_MASTERBYCAT, "Description", "ID", ddlCategory.SelectedValue);
             //    //ddlFaultLocation.Items.Insert(0, objListItem5);

             //}
             else
             {
                 //tr1.Visible = false;
                 //tr2.Visible = false;
                 //tr3.Visible = false;
                 //ddlFaultLocation.Enabled = true;
                 //trL1.Visible = false;
             }
             if (ddlApprovedStatus.SelectedValue == "Rejected")
             {
                 ddlApprovedStatus.Enabled = false;
                 txtApprovedDesc.Enabled = false;
                 txtReply.Enabled = true;
                 btnSave.Enabled = false;
                 btnResSubmitt.Enabled = true;
             }
             if (ddlApprovedStatus.SelectedValue == "On Hold")
             {
                 ddlApprovedStatus.Enabled = false;
                 txtApprovedDesc.Enabled = false;
                 txtReply.Enabled = true;
                 btnSave.Enabled = false;
                 btnResSubmitt.Enabled = true;
             }
        }
    }
    protected void ddlApprovedStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlApprovedStatus.SelectedIndex == 2)
        {
            btnSave.Text = "Submit For Reject";

        }
        if (ddlApprovedStatus.SelectedIndex == 3)
        {
            btnSave.Text = "Submit For On Hold";
        }
        if (ddlApprovedStatus.SelectedIndex == 1)
        {
            btnSave.Text = "Submit For On Approve";
        }

        if (ddlApprovedStatus.SelectedIndex == 3)
        {

            //btnSave.Text = "Submit For Reject";
            RadMultiPage1.SelectedIndex = 3;
            RadTabStrip1.SelectedIndex = 3;
            RadTabStrip1.Tabs[3].Selected = true;
        }
    }
    protected void btnResSubmitt_Click(object sender, EventArgs e)
    {
        int Icount = 0;
        DataTable dt = objSqLDataAccess.GetBindListById(DBSQL.GET_ISLEVEL_BYID, txtMworkOrder.Text);
        if (dt.Rows.Count > 0)
        {
            strAppLevel = Convert.ToString(dt.Rows[0]["apprLevel"]);
        }

        bsProperty.ID = Convert.ToString(Request.QueryString["ID"]);
        bsProperty.Description = txtReply.Text;
        if (strAppLevel == "" || strAppLevel == "0")
        {
            Icount = objSqLDataAccess.ResubmitJobOrderForEngr(bsProperty);
        }
        else
        {
            Icount = objSqLDataAccess.ResubmitJobOrder(bsProperty);
        }

        if (Icount > 0)
        {
            foreach (GridViewRow row in gvMaterial.Rows)
            {
                CheckBox CheckBox1 = row.Cells[15].Controls[0].FindControl("CheckBox1") as CheckBox;
                HiddenField HiddenField2 = row.Cells[15].Controls[1].FindControl("HiddenField2") as HiddenField;
                TextBox TextBox1 = row.Cells[5].Controls[0].FindControl("TextBox1") as TextBox;
                string ItemName = row.Cells[2].Text;
                string strUnit = row.Cells[4].Text;
                string strCase = row.Cells[6].Text.Trim();
                string strItemCode = row.Cells[1].Text.Trim();
                if (CheckBox1.Checked == true)
                {
                    bsProperty.IsBranch = "true";
                }
                else { bsProperty.IsBranch = "false"; }

                bsProperty.ID = HiddenField2.Value;
                bsProperty.UserName = Convert.ToString(Session["EName"]);
                bsProperty.Qty = TextBox1.Text;

                int ICount = objSqLDataAccess.VerifyMaterial(bsProperty);
            }

        }
    }
    private void UserRightApproval(string ID)
    {
        bsProperty.ID = ID;
        string strUser = Convert.ToString(Session["UserTypeID"]);
        if (strUser == "4" && HiddenField1.Value == "0")
        {
            bsProperty.OPerationManager = Convert.ToString(Session["EName"]);
            // bsProperty.OPerationManagerDate = Convert.ToString(DateTime.Now);
            ddlApprovedStatus.Enabled = true;
            txtApprovedDesc.Enabled = true;
            btnSave.Enabled = true;

          // int Icount5 = objSqLDataAccess.UpdateJobOrderItem(bsProperty);
            int Icount3 = objSqLDataAccess.UpdateJobItemMaster(bsProperty);
        }
        else if (strUser == "6" && HiddenField1.Value == "1")
        {
            bsProperty.ProjectManager = Convert.ToString(Session["EName"]);
            // bsProperty.ProjectManagerDate = Convert.ToString(DateTime.Now);
            ddlApprovedStatus.Enabled = true;
            txtApprovedDesc.Enabled = true;
            btnSave.Enabled = true;
            int Icount2 = objSqLDataAccess.UpdateProjJobItemMaster(bsProperty);
        }

        //else if (strUser == "7" && HiddenField1.Value == "2")
        //{
        //    bsProperty.EngineerApproval = Convert.ToString(Session["EName"]);
        //    //bsProperty.EngineerApprovalDate = Convert.ToString(DateTime.Now);
        //    ddlApprovedStatus.Enabled = true;
        //    txtApprovedDesc.Enabled = true;
        //    btnSave.Enabled = true;
        //    int Icount7 = objSqLDataAccess.UpdateEnggJobItemMaster(bsProperty);
        //}
        //else if (strUser == "12" && HiddenField1.Value == "3")
        //{
        //    bsProperty.FinalApproval = Convert.ToString(Session["EName"]);
        //    // bsProperty.FinalApprovalDate = Convert.ToString(DateTime.Now);
        //    ddlApprovedStatus.Enabled = true;
        //    txtApprovedDesc.Enabled = true;
        //    btnSave.Enabled = true;
        //    int Icount8 = objSqLDataAccess.UpdateMODMajorJobItemMaster(bsProperty);
        //}

        //else if (strUser == "8" && HiddenField1.Value == "3")
        //{
        //    bsProperty.FinalApproval = Convert.ToString(Session["EName"]);
        //    // bsProperty.FinalApprovalDate = Convert.ToString(DateTime.Now);
        //    ddlApprovedStatus.Enabled = true;
        //    txtApprovedDesc.Enabled = true;
        //    btnSave.Enabled = true;
        //    int Icount8 = objSqLDataAccess.UpdateMODJobItemMaster(bsProperty);
        //}

        //else if (strUser == "9" && HiddenField1.Value == "4")
        //{
        //    bsProperty.DirectorApproval = Convert.ToString(Session["EName"]);
        //    // bsProperty.FinalApprovalDate = Convert.ToString(DateTime.Now);
        //    ddlApprovedStatus.Enabled = true;
        //    txtApprovedDesc.Enabled = true;
        //    btnSave.Enabled = true;
        //    int Icount8 = objSqLDataAccess.UpdateDirectorJobItemMaster(bsProperty);
        //}


    }
    private void GetVerify()
    {
        if (HiddenField1.Value == "0" && ddlApprovedStatus.SelectedValue == "Approved")
        {
            bsProperty.Status = "Verified";
            bsProperty.IsDep = "1";
            bsProperty.UserName = "";
        }
        else if (HiddenField1.Value == "1" && ddlApprovedStatus.SelectedValue == "Approved")
        {
            bsProperty.Status = "Approved";
            bsProperty.IsDep = "2";
            bsProperty.UserName = "";
        }
        //else if (HiddenField1.Value == "2" && ddlApprovedStatus.SelectedValue == "Approved")
        //{
        //    bsProperty.Status = "Verified";
        //    bsProperty.IsDep = "3";
        //    bsProperty.UserName = "";
        //}
        //else if (HiddenField1.Value == "3" && ddlApprovedStatus.SelectedValue == "Approved")
        //{
        //    bsProperty.Status = "Verified";
        //    bsProperty.IsDep = "4";
        //    bsProperty.UserName = "";
        //}
        //else if (HiddenField1.Value == "4" && ddlApprovedStatus.SelectedValue == "Approved")
        //{
        //    bsProperty.Status = "Verified";
        //    bsProperty.IsDep = "5";
        //    bsProperty.UserName = "";
        //}
        //else if (HiddenField1.Value == "4" && ddlApprovedStatus.SelectedValue == "Approved")
        //{
        //    bsProperty.Status = "Approved";
        //    bsProperty.IsDep = "5";
        //    bsProperty.UserName = "";
        //}
        else
        {
            bsProperty.IsDep = HiddenField1.Value;
            bsProperty.UserName = Convert.ToString(Session["EName"]);
            bsProperty.Status = ddlApprovedStatus.SelectedValue;
        }
    }
    private void GetConsumableVerify()
    {
        if (HiddenField1.Value == "0" && ddlApprovedStatus.SelectedValue == "Approved")
        {
            bsProperty.Status = "Approved";
            bsProperty.IsDep = "1";
            bsProperty.UserName = "";
        }
        //else if (HiddenField1.Value == "1" && ddlApprovedStatus.SelectedValue == "Approved")
        //{
        //    bsProperty.Status = "Approved";
        //    bsProperty.IsDep = "2";
        //    bsProperty.UserName = "";
        //}

        //else if (HiddenField1.Value == "2" && ddlApprovedStatus.SelectedValue == "Approved")
        //{
        //    bsProperty.Status = "Verified";
        //    bsProperty.IsDep = "3";
        //    bsProperty.UserName = "";
        //}
        //else if (HiddenField1.Value == "3" && ddlApprovedStatus.SelectedValue == "Approved")
        //{
        //    bsProperty.Status = "Approved";
        //    bsProperty.IsDep = "4";
        //    bsProperty.UserName = "";
        //}
        else
        {
            bsProperty.IsDep = HiddenField1.Value;
            bsProperty.UserName = Convert.ToString(Session["EName"]);
            bsProperty.Status = ddlApprovedStatus.SelectedValue;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DataTable dtOrder = objSqLDataAccess.GetBindList(DBSQL.GET_MRFNO);
        if (dtOrder.Rows.Count > 0)
        {
            bsProperty.MRNO = Convert.ToString(dtOrder.Rows[0]["SValue"]);
        }

        bsProperty.JobOrderNo = txtMworkOrder.Text;
        bsProperty.Description = txtApprovedDesc.Text;
        if (txtMCategory.Text == "Consumable")
        {
            GetConsumableVerify();
        }
        else
        {
            GetConsumableVerify();
        }
        int Icount = objSqLDataAccess.AddApprovedWorkOrder(bsProperty);
        if (Icount > 0)
        {
            bsProperty.UserName = Convert.ToString(Session["EName"]);
            bsProperty.Status = ddlApprovedStatus.SelectedValue;
            int Icount1 = objSqLDataAccess.UpdateLastAction(bsProperty);
            int Icount2 = objSqLDataAccess.JobComments(bsProperty);

            lblApprovedMessage.Text = "Work Order has been " + ddlApprovedStatus.SelectedValue + "Successfully!";
            btnSave.Enabled = false;
        }

        foreach (GridViewRow row in gvMaterial.Rows)
        {
            CheckBox CheckBox1 = row.Cells[15].Controls[0].FindControl("CheckBox1") as CheckBox;
            HiddenField HiddenField2 = row.Cells[15].Controls[1].FindControl("HiddenField2") as HiddenField;
            TextBox TextBox1 = row.Cells[5].Controls[0].FindControl("TextBox1") as TextBox;
            LinkButton LinkButton1 = row.Cells[1].Controls[0].FindControl("LinkButton1") as LinkButton;
            
            string ItemName = row.Cells[2].Text;
            string strUnit = row.Cells[4].Text;
            string strCase = row.Cells[6].Text.Trim();
            string strItemCode = LinkButton1.Text;


            if (CheckBox1.Checked == true && ddlApprovedStatus.SelectedValue == "Approved" )
            {
                bsProperty.ID = HiddenField2.Value;
                bsProperty.Qty = TextBox1.Text;
                UserRightApproval(HiddenField2.Value);
            }

            if (CheckBox1.Checked == true && ddlApprovedStatus.SelectedValue == "Approved" && strCase == "Available")
            {

                bsProperty.ID = "0";
                bsProperty.JobOrderNo = txtMworkOrder.Text;
                bsProperty.Status = ddlApprovedStatus.SelectedValue;
                bsProperty.ItemName = ItemName;
                bsProperty.UnitNo = strUnit;
                bsProperty.Qty = TextBox1.Text.Trim();
                bsProperty.ItemCode = strItemCode;
                if (HiddenField1.Value == "0" && txtMCategory.Text == "Reimbursable")
                {
                    int ICount = objSqLDataAccess.ApprovedMaterial(bsProperty);
                    if (ICount > 0)
                    {
                        lblApprovedMessage.Text = "Work Order has been " + ddlApprovedStatus.SelectedValue + "Successfully!";
                    }
                }

                if (HiddenField1.Value == "0" && txtMCategory.Text == "Consumable")
                {
                    int ICount = objSqLDataAccess.ApprovedMaterial(bsProperty);
                    if (ICount > 0)
                    {
                        lblApprovedMessage.Text = "Work Order has been " + ddlApprovedStatus.SelectedValue + "Successfully!";
                    }
                }

            }

            if (CheckBox1.Checked == true && ddlApprovedStatus.SelectedValue == "Approved" && strCase == "Purchase")
            {
                bsProperty.ItemCode = strItemCode;
                bsProperty.ItemName = ItemName;
                bsProperty.Specification = "";
                bsProperty.Qty = TextBox1.Text;
                bsProperty.MRFNumber = bsProperty.MRNO;
                bsProperty.UnitNo = strUnit;
                bsProperty.ID = "0";

                bsProperty.ReferenceName = "Work Order : " + txtMworkOrder.Text + " Location: " + txtMLocation.Text;
                bsProperty.Project = "6";
                bsProperty.ApplyDate = Convert.ToString(dtWorkOrderNo.SelectedDate);
                bsProperty.Status = "Approved";
                bsProperty.UserName = "";
                bsProperty.IsDep = HiddenField1.Value;
                if (txtMCategory.Text == "Reimbursable" && HiddenField1.Value == "0")
                {

                    int Icount1 = objSqLDataAccess.AddMatarialRequest(bsProperty);
                    int Icount2 = objSqLDataAccess.AddMatarialItem(bsProperty);
                }

                if (txtMCategory.Text == "Consumable" && HiddenField1.Value == "0")
                {
                    int Icount1 = objSqLDataAccess.AddMatarialRequest(bsProperty);
                    int Icount2 = objSqLDataAccess.AddMatarialItem(bsProperty);
                }
            }
        }
    }
    protected void gvMaterial_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string Status = e.Row.Cells[6].Text;

            TextBox TextBox1 = (TextBox)e.Row.FindControl("TextBox1");
            
            if (Status == "Available")
            {

                TextBox1.Enabled = true;
                string strUserTypeID = Convert.ToString(Session["UserTypeID"]);
                if (strUserTypeID == "4")
                {
                    TextBox1.Enabled = true;
                }
                else
                {
                    TextBox1.Enabled = false;
                }

            }
        }
    }
    protected void btnForward_Click(object sender, EventArgs e)
    {
        bsProperty.ID = ddlUser.SelectedValue;
        bsProperty.JobOrderNo = txtJobOrder.Text;
        int Icount = objSqLDataAccess.JobOrderForwarded(bsProperty);
        if (Icount > 0)
        {
            bsProperty.Description = txtDescription2.Text;
            bsProperty.UserName = Convert.ToString(Session["EName"]);
            bsProperty.Status = "Forwarded To " + ddlUser.SelectedItem.Text;
            int Icount1 = objSqLDataAccess.UpdateLastAction(bsProperty);
            int Icount2 = objSqLDataAccess.JobComments(bsProperty);
            lblMessageFor.Text = "Job order has been forwarded Successfully!";

            foreach (ListItem item1 in chkUser.Items)
            {
                if (item1.Selected)
                {
                    bsProperty.JobOrderNo = txtJobOrder.Text;

                    //bsProperty.ID=
                    //string id = Convert.ToString(gvUser.DataKeys[row.RowIndex]["ID"]);

                    bsProperty.ReportTo = item1.Value;
                    string strSender = Convert.ToString(Session["ID"]);
                    bsProperty.UserName = strSender;
                    bsProperty.Description = txtDescription2.Text;

                    int Icount5 = objSqLDataAccess.SendMRMsessage(bsProperty);
                }
            }


        }
    }
    protected void gvProject_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //string strIssued = e.Row.Cells[5].Text.Replace("&nbsp;","");
            Label lblIssued1 = (Label)e.Row.FindControl("lblIssued1");
            Label lblIssued2 = (Label)e.Row.FindControl("lblIssued2");
            Label lblIssued3 = (Label)e.Row.FindControl("lblIssued2");
            string strCode = e.Row.Cells[2].Text;

            DataTable dt = objSqLDataAccess.GetBindListById(DBSQL.GET_RESEARVED3, strCode);
            if (dt.Rows.Count > 0)
            {
                lblIssued2.Text = Convert.ToString(dt.Rows[0]["TotalResv"]);
            }

            if (lblIssued1.Text == "")
            {
                lblIssued1.Text = "0";


            }
            if (lblIssued2.Text == "0")
            {
                lblIssued2.Text = "";
            }



            e.Row.Cells[6].Text = Convert.ToString(Convert.ToInt32(e.Row.Cells[4].Text) - Convert.ToInt32(lblIssued1.Text));
            if (lblIssued2.Text == "")
            {
                int Res = 0;
                e.Row.Cells[9].Text = Convert.ToString(Convert.ToInt32(e.Row.Cells[6].Text) - Convert.ToInt32(Res));
            }
            else
            {
                e.Row.Cells[9].Text = Convert.ToString(Convert.ToInt32(e.Row.Cells[6].Text) - Convert.ToInt32(lblIssued2.Text));
            }

            int IRes = Convert.ToInt32(e.Row.Cells[9].Text);
            if (IRes < 0)
            {
                e.Row.Cells[9].Text = "0";
                //lblIssued2.Text = "";
            }


        }
    }
    protected void gvMaterial_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "btnItem")
        {
            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            LinkButton btnCode = row.Cells[1].Controls[0].FindControl("LinkButton1") as LinkButton;
            bsProperty.LCategory = "0";
            bsProperty.ItemCode = btnCode.Text;
            bsProperty.ItemName = "";
            bsProperty.DedType = "0";
            DataTable dt = objSqLDataAccess.GetStockInventoryByID(bsProperty);
            gvProject.DataSource = dt;
            gvProject.DataBind();
        }
    }
}