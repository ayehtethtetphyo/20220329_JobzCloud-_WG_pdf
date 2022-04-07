using Common;
using MySql.Data.MySqlClient;
using Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace jobzcolud.WebFront
{

    public partial class JC37Shohin : System.Web.UI.Page
    {
        #region Declaration
        MySqlConnection con = null;
        bool f_isomoji_msg = true;
        JC37Shohin_Class jc = new JC37Shohin_Class();
        #endregion
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginId"] != null)
            {
                if (!IsPostBack)
                {
                    JC99NavBar navbar_Master = (JC99NavBar)this.Master;
                    navbar_Master.lnkBtnSetting.Style.Add(" background-color", "rgba(46,117,182)");
                    navbar_Master.navbar2.Visible = false;

                    //div3.Visible = true;
                    divPopupHeader.Visible = false;
                    btCancel.Visible = false;
                    DivLine.Visible = false;
                    if (Session["fSyouhinSyosai"] != null)
                    {
                        if (Session["fSyouhinSyosai"].ToString() == "Popup")
                        {
                            if (SessionUtility.GetSession("HOME") != null)
                            {
                                hdnHome.Value = SessionUtility.GetSession("HOME").ToString();
                                SessionUtility.SetSession("HOME", null);
                            }
                            HF_flag.Value = Session["fSyouhinSyosai"].ToString();
                            navbar_Master.div_Nav.Visible = false;
                            navbar_Master.div2.Visible = false;
                            BD_Syouhin.Style.Add("background-color", "transparent");
                            navbar_Master.divContent.Style.Add("background-color", "transparent");
                            navbar_Master.form1.Style.Add("background-color", "transparent");
                            navbar_Master.BD_Master.Style.Add("background-color", "transparent");
                            Div_Body.Style.Add("background-color", "transparent");
                            // div3.Visible = false;
                            divPopupHeader.Visible = true;
                            btCancel.Visible = true;
                            DivLine.Visible = true;
                            DDL_TANIBIND();

                        }

                    }
                }
            }
            else
            {
                Response.Redirect("JC01Login.aspx");
            }

        }
        #endregion
        #region DDL_TANI Bind
        private void DDL_TANIBIND()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            string getsTANI = " select distinct cTANI, sTANI from M_TANI order by cTANI ";
            jc.loginId = Session["LoginId"].ToString();
            dt = jc.SyouhinListTable(getsTANI);
            DDL_cTANI.DataSource = dt;
            DDL_cTANI.DataTextField = "sTANI";
            DDL_cTANI.DataValueField = "sTANI";
            DDL_cTANI.DataBind();
            DDL_cTANI.Items.Insert(0, new ListItem(" ", "00"));
        }
        #endregion
        #region checkData
        private void checkData()
        {
            if (txtsSyouhin.Text != "")
            {
                txtsSyouhin.BorderColor = System.Drawing.Color.LightGray;
                txtsSyouhin.BorderStyle = BorderStyle.Solid;
                txtsSyouhin.BorderWidth = 1;

                HF_checkData.Value = "1";

            }
            else
            {
                HF_checkData.Value = "0";
                if (txtsSyouhin.Text == "")
                {
                    txtsSyouhin.BorderColor = System.Drawing.Color.Red;
                    txtsSyouhin.BorderStyle = BorderStyle.Double;
                    txtsSyouhin.BorderWidth = 2;
                }

                updHeader.Update();
            }
        }
        #endregion

        #region BT_Save_Click
        protected void BT_Save_Click(object sender, EventArgs e)
        {
            checkData();
            Boolean saveSuccess = false;
            if (HF_checkData.Value == "1")
            {
                if (TextUtility.isomojiCharacter(txtsSyouhin.Text))
                {
                    f_isomoji_msg = false;
                }
                String sSYOUHIN = txtsSyouhin.Text.Replace("\\", "\\\\").Replace("'", "\\'");  //商品名
                if (TextUtility.isomojiCharacter(TB_Shohinryakusho.Text))
                {
                    f_isomoji_msg = false;
                }
                String sSYOUHIN_R = TB_Shohinryakusho.Text.Replace("\\", "\\\\").Replace("'", "\\'");  //商品略称
                if (TextUtility.isomojiCharacter(TB_Junban.Text))
                {
                    f_isomoji_msg = false;
                }
                // String nJUNBAN = TB_Junban.Text.Replace("\\", "\\\\").Replace("'", "\\'");  //順番
                String nJUNBAN = "0";
                if (!String.IsNullOrEmpty(TB_Junban.Text))
                {
                    nJUNBAN = TB_Junban.Text.Replace(",", "");
                }
                if (TextUtility.isomojiCharacter(TB_TsukamatsuKakaku.Text))
                {
                    f_isomoji_msg = false;
                }
                String nSHIIREKAKAKU = "0";//仕ス価格
                 // nSHIIREKAKAKU = TB_TsukamatsuKakaku.Text.Replace("\\", "\\\\").Replace("'", "\\'"); 
                if (!String.IsNullOrEmpty(TB_TsukamatsuKakaku.Text))
                {
                    nSHIIREKAKAKU = TB_TsukamatsuKakaku.Text.Replace(",", "");
                }
                String nHANNBAIKAKAKU = "0"; //販売価格
                if (TextUtility.isomojiCharacter(TB_HanbaiKakaku.Text))
                {
                    f_isomoji_msg = false;
                }
                // String nHANNBAIKAKAKU = TB_HanbaiKakaku.Text.Replace("\\", "\\\\").Replace("'", "\\'"); 
                if (!String.IsNullOrEmpty(TB_HanbaiKakaku.Text))
                {
                    nHANNBAIKAKAKU = TB_HanbaiKakaku.Text.Replace(",", "");
                }

                String nSYOUKISU = "0";  //見積初期数
                if (TextUtility.isomojiCharacter(TB_MitsumoriSyokisu.Text))
                {
                    f_isomoji_msg = false;
                }
                if (!String.IsNullOrEmpty(TB_MitsumoriSyokisu.Text))
                {
                    nSYOUKISU = TB_MitsumoriSyokisu.Text.Replace(",", "");
                }
                //String nSYOUKISU = TB_MitsumoriSyokisu.Text.Replace("\\", "\\\\").Replace("'", "\\'");  //見積初期数
                //if (TextUtility.isomojiCharacter(TB_Tani.Text))
                //{
                //    f_isomoji_msg = false;
                //}
                //String sTANI = TB_Tani.Text.Replace("\\", "\\\\").Replace("'", "\\'");  //単位
               // String sTANI = DDL_cTANI.SelectedValue; //単位
                String sTANI = txtTani.Text.Trim().Replace("\r\n", "").Replace("\r", "").Replace("\n", "");//単位

                // String nSIZE_X = TB_SizeX.Text.Replace("\\", "\\\\").Replace("'", "\\'");  // サイズX
                String nSIZE_X = "0";  // サイズX

                if (!String.IsNullOrEmpty(TB_SizeX.Text))
                {
                    nSIZE_X = TB_SizeX.Text.Replace(",", "");
                }
                if (TextUtility.isomojiCharacter(TB_SizeX.Text))
                {
                    f_isomoji_msg = false;
                }
                String cTANI_X = DD_SizeX.SelectedValue;  // サイズX

                // String nSIZE_Y = TB_SizeY.Text.Replace("\\", "\\\\").Replace("'", "\\'");  // サイズY
                String nSIZE_Y = "0";  // サイズY

                if (!String.IsNullOrEmpty(TB_SizeY.Text))
                {
                    nSIZE_Y = TB_SizeY.Text.Replace(",", "");
                }
                if (TextUtility.isomojiCharacter(TB_SizeY.Text))
                {
                    f_isomoji_msg = false;
                }
                String cTANI_Y = DD_SizeY.SelectedValue;  // サイズX

                //  String nSIZE_Z = TB_SizeZ.Text.Replace("\\", "\\\\").Replace("'", "\\'");  // サイズZ
                String nSIZE_Z = "0";  // サイズZ
                if (!String.IsNullOrEmpty(TB_SizeZ.Text))
                {
                    nSIZE_Y = TB_SizeZ.Text.Replace(",", "");
                }
                if (TextUtility.isomojiCharacter(TB_SizeZ.Text))
                {
                    f_isomoji_msg = false;
                }
                String cTANI_Z = DD_SizeZ.SelectedValue;  // サイズZ
                if (TextUtility.isomojiCharacter(TB_Shiyou.Text))
                {
                    f_isomoji_msg = false;
                }
                String sSHIYOU = TB_Shiyou.Text.Replace("\\", "\\\\").Replace("'", "\\'");  // 仕様
                if (TextUtility.isomojiCharacter(txtBikou.Text))
                {
                    f_isomoji_msg = false;
                }
                String sBIKOU = txtBikou.Text.Replace("\\", "\\\\").Replace("'", "\\'");  // 商品備考 

                String nOMOSA = "0";  // 重さ
                if (!String.IsNullOrEmpty(TB_Omosa.Text))
                {
                    nOMOSA = TB_Omosa.Text.Replace(",", "");
                }
                if (TextUtility.isomojiCharacter(TB_Omosa.Text))
                {
                    f_isomoji_msg = false;
                }


                // nOMOSA = TB_Omosa.Text.Replace("\\", "\\\\").Replace("'", "\\'");  //  重さ 

                if (TextUtility.isomojiCharacter(TB_KataBan.Text))
                {
                    f_isomoji_msg = false;
                }
                String sKATABAN = TB_KataBan.Text.Replace("\\", "\\\\").Replace("'", "\\'");  //   型番
                if (TextUtility.isomojiCharacter(TB_Meka.Text))
                {
                    f_isomoji_msg = false;
                }
                String sMEKA = TB_Meka.Text.Replace("\\", "\\\\").Replace("'", "\\'");  //   メーカー
                string Chkmidashi = "0";
                if (Chk_midashi.Checked == true)
                {
                    Chkmidashi = "1";
                }
                string Chkhaiban = "0";
                if (Chk_haiban.Checked == true)
                {
                    Chkhaiban = "1";
                }
                if (f_isomoji_msg == false)
                {
                    string msg = "使用不可能なテキスト（環境依存文字）が入力され保存できません。</br>文字化けの原因となるため、下記の文字を修正してください。</br>" + " 対象文字：「" + TextUtility.invalidtext_all + "」";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowAnkenChangeMessage",
                                "ShowMojiMessage('" + msg + "','" + btnmojiOK.ClientID + "');", true);
                    f_isomoji_msg = true;
                    Session["moji"] = "true";
                }
                else
                {

                    #region getcSYOUHIN
                    string cCoVal = FindSyouhinCode();
                    JC_ClientConnecction_Class jc = new JC_ClientConnecction_Class();
                    jc.loginId = Session["LoginId"].ToString();
                    con = jc.GetConnection();
                    DataTable dt_loginuser = jc.GetLoginUserCodeFromClientDB();
                    String cHENKOUSYA = dt_loginuser.Rows[0]["code"].ToString();
                    LB_SyouhinCode.Text = cCoVal;
                    #endregion
                    try
                    {
                        String dHENKOUDate = DateTime.Now.ToString();
                        string allinsertquery = "";
                        allinsertquery += "INSERT INTO m_syouhin" +
                                          "(cSYOUHIN,sSYOUHIN,sSYOUHIN_R,nJUNBAN,nSHIIREKAKAKU,nHANNBAIKAKAKU,nSYOUKISU," +
                                           "sTANI,nSIZE_X,nSIZE_Y,nSIZE_T,cTANI_X,cTANI_Y,cTANI_T,sSHIYOU,cSYOUHIN_DAIGRP,cSYOUHIN_TYUUGRP," +
                                           "cSHIIRESAKI,sBIKOU,nOMOSA,sKATABAN,sMEKA,fmidashi,fHAIBAN,dHENKOU,cHENKOUSYA) VALUES  ";
                        allinsertquery += "('" + cCoVal + "','" + sSYOUHIN + "','" + sSYOUHIN_R + "', " + nJUNBAN + ", '" + nSHIIREKAKAKU + "', '" + nHANNBAIKAKAKU + "','" + nSYOUKISU + "',";
                        allinsertquery += " '" + sTANI + "', '" + nSIZE_X + "'," + nSIZE_Y + "," + nSIZE_Z + ",'" + cTANI_X + "','" + cTANI_Y + "','" + cTANI_Z + "','" + sSHIYOU + "',";
                        allinsertquery += " '" + lblcSYOUHINDAIGRP.Text + "', '" + lblcSYOUHINTYUUGRP.Text + "','" + lblcSHIIRESAKI.Text + "','" + sBIKOU + "','" + nOMOSA + "','" + sKATABAN + "','" + sMEKA + "'," + Chkmidashi + "," + Chkhaiban + ",";
                        allinsertquery += "'" + dHENKOUDate + "','" + cHENKOUSYA + "')";

                        allinsertquery += " ON DUPLICATE KEY UPDATE " +
                                              "cSYOUHIN = VALUES(cSYOUHIN), " +
                                              "sSYOUHIN = VALUES(sSYOUHIN)," +
                                               "sSYOUHIN_R = VALUES(sSYOUHIN_R)," +
                                                "nJUNBAN = VALUES(nJUNBAN)," +
                                                "nSHIIREKAKAKU = VALUES(nSHIIREKAKAKU)," +
                                                "nHANNBAIKAKAKU = VALUES(nHANNBAIKAKAKU)," +
                                                "nSYOUKISU = VALUES(nSYOUKISU)," +
                                                "sTANI = VALUES(sTANI)," +
                                                "nSIZE_X = VALUES(nSIZE_X)," +
                                                "nSIZE_Y = VALUES(nSIZE_Y)," +
                                                "nSIZE_T = VALUES(nSIZE_T)," +
                                                "cTANI_X = VALUES(cTANI_X)," +
                                                "cTANI_Y = VALUES(cTANI_Y)," +
                                                "cTANI_T = VALUES(cTANI_T)," +
                                                "sSHIYOU = VALUES(sSHIYOU)," +
                                                "cSYOUHIN_DAIGRP = VALUES(cSYOUHIN_DAIGRP)," +
                                                "cSYOUHIN_TYUUGRP = VALUES(cSYOUHIN_TYUUGRP)," +
                                                "cSHIIRESAKI = VALUES(cSHIIRESAKI)," +
                                                "sBIKOU = VALUES(sBIKOU)," +
                                                "nOMOSA = VALUES(nOMOSA)," +
                                                "sKATABAN = VALUES(sKATABAN)," +
                                                "sMEKA = VALUES(sMEKA)," +
                                                "fmidashi = VALUES(fmidashi)," +
                                              "fHAIBAN = VALUES(fHAIBAN)," +
                                              "dHENKOU= VALUES(dHENKOU),cHENKOUSYA= VALUES(cHENKOUSYA);";

                        con.Open();
                        MySqlCommand cmdInsert = new MySqlCommand(allinsertquery, con);
                        cmdInsert.CommandTimeout = 0;
                        cmdInsert.ExecuteNonQuery();
                        con.Close();

                        saveSuccess = true;

                        //divLabelSave.Style["display"] = "flex";//「保存しました。」メッセージを表示                                                                                                                                      
                        //updLabelSave.Update();
                        HF_flag.Value = "0";
                        //HF_Save.Value = "1";
                        updHeader.Update();

                    }
                    catch (Exception ex)
                    {

                    }
                    if (saveSuccess)
                    {
                        //hdnHome.Value = "Master";
                        if (HF_flag.Value == "Popup")
                        {

                            ScriptManager.RegisterStartupScript(this, GetType(), "CallMyFunction", "parentButtonClick('btnSyouhinNew_Close','" + hdnHome.Value + "');", true);
                        }
                        else
                        {
                            Session["fSyouhinSyosai"] = null;
                            if (Chk_haiban.Checked == false)
                            {
                                Session["cSyohin"] = LB_SyouhinCode.Text;
                               // Session["fHaiban"] = "0";
                            }
                            Session["sSyohin"] = txtsSyouhin.Text;
                            if (Session["fGamen"] != null)
                            {
                                if (Session["fGamen"].ToString() == "Setting")
                                {
                                    Session["fGamen"] = null;
                                    ScriptManager.RegisterStartupScript(this, GetType(), "CallMyFunction", "parentButtonClick('btn_Close','Master');", true);
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "CallMyFunction", "parentButtonClick('btnSyouhinNew_Close','" + hdnHome.Value + "');", true);
                            }
                        }
                    }
                }
            }

        }
        #endregion
        #region txtTani_TextChanged
        protected void txtTani_TextChanged(object sender, EventArgs e)
        {
        }
        #endregion
        #region DDL_cTANI_SelectedIndexChanged
        protected void DDL_cTANI_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTani.Text= DDL_cTANI.SelectedItem.ToString();
        }
        #endregion

        #region btnSyouhin_Auto_Click
        protected void btnSyouhin_Auto_Click(object sender, EventArgs e)
        {
            #region getcSYOUHIN
            string cCoVal = FindSyouhinCode();
            LB_SyouhinCode.Text = cCoVal;
            #endregion
        }
        #endregion
        #region　FindSyouhinCode
        protected string FindSyouhinCode()
        {
            string ColVal = "";
            System.Data.DataTable dt = new System.Data.DataTable();
            string sqlStr = "SELECT cSYOUHIN FROM m_syouhin; ";
            jc.loginId = Session["LoginId"].ToString();
            dt = jc.SyouhinListTable(sqlStr);
            //finding the missing number 
            List<int> ListShain = new List<int>();
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                ListShain.Add(int.Parse(dr["cSYOUHIN"].ToString()));
            }
            if (ListShain.Count > 0)
            {
                var MissingNumbers = Enumerable.Range(1, 9999).Except(ListShain).ToList();
                var ResultNum = MissingNumbers.Min();
                ColVal = ResultNum.ToString().PadLeft(10, '0');
            }
            else
            {
                var MissingNumbers = 1;
                ColVal = MissingNumbers.ToString().PadLeft(10, '0');
            }
            return ColVal;
        }
        #endregion
        #region TB_Junban_TextChanged
        protected void TB_Junban_TextChanged(object sender, EventArgs e)
        {
            if (TB_Junban.Text != "")
            {
                if (TextUtility.IsIncludeZenkaku(TB_Junban.Text))
                {

                    lbl_JunbanErr.Text = "半角英数を入力してください。";
                    TB_Junban.Text = "";
                    TB_Junban.Focus();
                }
                else
                {
                    lbl_JunbanErr.Text = "";
                }
            }
            else
            {
                lbl_JunbanErr.Text = "";
            }
        }
        #endregion
        #region TB_TsukamatsuKakaku_TextChanged
        protected void TB_TsukamatsuKakaku_TextChanged(object sender, EventArgs e)
        {
            if (TB_TsukamatsuKakaku.Text != "")
            {
                if (TextUtility.IsIncludeZenkaku(TB_TsukamatsuKakaku.Text))
                {

                    lbl_TsukamatsuKakaku.Text = "半角英数を入力してください。";
                    TB_TsukamatsuKakaku.Text = "";
                    TB_TsukamatsuKakaku.Focus();
                }
                else
                {
                    lbl_TsukamatsuKakaku.Text = "";
                    try
                    {
                        Decimal number = Convert.ToDecimal(TB_TsukamatsuKakaku.Text.Replace(",", ""));
                        TB_TsukamatsuKakaku.Text = number.ToString("#,##0");
                        if (TB_TsukamatsuKakaku.Text.StartsWith("-"))
                        {
                            TB_TsukamatsuKakaku.ForeColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            TB_TsukamatsuKakaku.ForeColor = System.Drawing.Color.Black;
                        }
                    }
                    catch
                    {
                        TB_TsukamatsuKakaku.Text = "";
                    }
                }
            }
            else
            {
                lbl_TsukamatsuKakaku.Text = "";
            }

            //HF_isChange.Value = "1";
            //updHeader.Update();
        }
        #endregion
        #region TB_HanbaiKakaku_TextChanged
        protected void TB_HanbaiKakaku_TextChanged(object sender, EventArgs e)
        {
            if (TB_HanbaiKakaku.Text != "")
            {
                if (TextUtility.IsIncludeZenkaku(TB_HanbaiKakaku.Text))
                {

                    lbl_HanbaiKakaku.Text = "半角英数を入力してください。";
                    TB_HanbaiKakaku.Text = "";
                    TB_HanbaiKakaku.Focus();
                }
                else
                {
                    lbl_HanbaiKakaku.Text = "";
                    try
                    {
                        Decimal number = Convert.ToDecimal(TB_HanbaiKakaku.Text.Replace(",", ""));
                        TB_HanbaiKakaku.Text = number.ToString("#,##0");
                        if (TB_HanbaiKakaku.Text.StartsWith("-"))
                        {
                            TB_HanbaiKakaku.ForeColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            TB_HanbaiKakaku.ForeColor = System.Drawing.Color.Black;
                        }
                    }
                    catch
                    {
                        TB_HanbaiKakaku.Text = "";
                    }
                }
            }
            else
            {
                lbl_HanbaiKakaku.Text = "";
            }
        }
        #endregion

        #region TB_MitsumoriSyokisu_TextChanged
        protected void TB_MitsumoriSyokisu_TextChanged(object sender, EventArgs e)
        {
            if (TB_MitsumoriSyokisu.Text != "")
            {
                if (TextUtility.IsIncludeZenkaku(TB_MitsumoriSyokisu.Text))
                {

                    lbl_MitsumoriSyokisu.Text = "半角英数を入力してください。";
                    TB_MitsumoriSyokisu.Text = "";
                    TB_MitsumoriSyokisu.Focus();
                }
                else
                {
                    lbl_MitsumoriSyokisu.Text = "";
                    try
                    {
                        Decimal number = Convert.ToDecimal(TB_MitsumoriSyokisu.Text.Replace(",", ""));
                        TB_MitsumoriSyokisu.Text = number.ToString("#,##0");
                        if (TB_MitsumoriSyokisu.Text.StartsWith("-"))
                        {
                            TB_MitsumoriSyokisu.ForeColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            TB_MitsumoriSyokisu.ForeColor = System.Drawing.Color.Black;
                        }
                    }
                    catch
                    {
                        TB_MitsumoriSyokisu.Text = "";
                    }
                }
            }
            else
            {
                lbl_MitsumoriSyokisu.Text = "";
            }
        }
        #endregion

        #region TB_SizeX_TextChanged
        protected void TB_SizeX_TextChanged(object sender, EventArgs e)
        {
            if (TB_SizeX.Text != "")
            {
                if (TextUtility.IsIncludeZenkaku(TB_SizeX.Text))
                {

                    Lbl_SizeX.Text = "半角英数を入力してください。";
                    TB_SizeX.Text = "";
                    TB_SizeX.Focus();
                }
                else
                {
                    Lbl_SizeX.Text = "";
                    try
                    {
                        Decimal number = Convert.ToDecimal(TB_SizeX.Text.Replace(",", ""));
                        TB_SizeX.Text = number.ToString("#,##0");
                        if (TB_SizeX.Text.StartsWith("-"))
                        {
                            TB_SizeX.ForeColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            TB_SizeX.ForeColor = System.Drawing.Color.Black;
                        }
                    }
                    catch
                    {
                        TB_SizeX.Text = "";
                    }
                }
            }
            else
            {
                Lbl_SizeX.Text = "";
            }
        }
        #endregion
        #region TB_SizeY_TextChanged
        protected void TB_SizeY_TextChanged(object sender, EventArgs e)
        {
            if (TB_SizeY.Text != "")
            {
                if (TextUtility.IsIncludeZenkaku(TB_SizeY.Text))
                {

                    lbl_SizeY.Text = "半角英数を入力してください。";
                    TB_SizeY.Text = "";
                    TB_SizeY.Focus();
                }
                else
                {
                    lbl_SizeY.Text = "";
                    try
                    {
                        Decimal number = Convert.ToDecimal(TB_SizeY.Text.Replace(",", ""));
                        TB_SizeY.Text = number.ToString("#,##0");
                        if (TB_SizeY.Text.StartsWith("-"))
                        {
                            TB_SizeY.ForeColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            TB_SizeY.ForeColor = System.Drawing.Color.Black;
                        }
                    }
                    catch
                    {
                        TB_SizeY.Text = "";
                    }
                }
            }
            else
            {
                lbl_SizeY.Text = "";
            }
        }
        #endregion
        #region TB_SizeZ_TextChanged
        protected void TB_SizeZ_TextChanged(object sender, EventArgs e)
        {
            if (TB_SizeZ.Text != "")
            {
                if (TextUtility.IsIncludeZenkaku(TB_SizeZ.Text))
                {

                    lbl_SizeZ.Text = "半角英数を入力してください。";
                    TB_SizeZ.Text = "";
                    TB_SizeZ.Focus();
                }
                else
                {
                    lbl_SizeZ.Text = "";
                    try
                    {
                        Decimal number = Convert.ToDecimal(TB_SizeZ.Text.Replace(",", ""));
                        TB_SizeZ.Text = number.ToString("#,##0");
                        if (TB_SizeZ.Text.StartsWith("-"))
                        {
                            TB_SizeZ.ForeColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            TB_SizeZ.ForeColor = System.Drawing.Color.Black;
                        }
                    }
                    catch
                    {
                        TB_SizeZ.Text = "";
                    }
                }
            }
            else
            {
                lbl_SizeZ.Text = "";
            }
        }
        #endregion

        #region TB_Omosa_TextChanged
        protected void TB_Omosa_TextChanged(object sender, EventArgs e)
        {
            if (TB_Omosa.Text != "")
            {
                if (TextUtility.IsIncludeZenkaku(TB_Omosa.Text))
                {

                    lbl_Omosa.Text = "半角英数を入力してください。";
                    TB_Omosa.Text = "";
                    TB_Omosa.Focus();
                }
                else
                {
                    lbl_Omosa.Text = "";
                    try
                    {
                        Decimal number = Convert.ToDecimal(TB_Omosa.Text.Replace(",", ""));
                        TB_Omosa.Text = number.ToString("#,##0");
                        if (TB_SizeZ.Text.StartsWith("-"))
                        {
                            TB_Omosa.ForeColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            TB_Omosa.ForeColor = System.Drawing.Color.Black;
                        }
                    }
                    catch
                    {
                        TB_Omosa.Text = "";
                    }
                }
            }
            else
            {
                lbl_Omosa.Text = "";
            }
        }
        #endregion

        //#region BT_ShohinDaibunri_Add_Click
        //protected void BT_ShohinDaibunri_Add_Click(object sender, EventArgs e)
        //{
        //    Session["fSyouhinSyosai"] = "Popup";
        //    //SessionUtility.SetSession("HOME", "Master");
        //    //ifShohinDiaPopup.Style["width"] = "450px";//ジイー20220324
        //    //ifShohinDiaPopup.Style["height"] = "620px";//ジイー20220324
        //    //ifShohinDiaPopup.Src = "JC38Daibunrui.aspx";
        //    //mpeShohinDiaPopup.Show();

        //    //lblsSYOUHINDAIGRP.Attributes.Add("onClick", "BtnClick('MainContent_BT_ShohinDaibunri_Add')");
        //    //updShohinDiaPopup.Update();

        //    SessionUtility.SetSession("HOME", "Master");
        //    //ifDaibunruiPopup.Style["width"] = "715px";
        //    //ifDaibunruiPopup.Style["width"] = "530px";
        //    //ifDaibunruiPopup.Style["height"] = "100vh";
        //    ifShohinDiaPopup.Style["width"] = "450px";//ジイー20220324
        //    ifShohinDiaPopup.Style["height"] = "620px";//ジイー20220324
        //    //ifDaibunruiPopup.Style["width"] = "440px";
        //    //ifDaibunruiPopup.Style["height"] = "392px";
        //    ifShohinDiaPopup.Src = "JC38Daibunrui.aspx";
        //    mpeShohinDiaPopup.Show();
        //    Session["fDai"] = "true";

        //    lblsSYOUHINDAIGRP.Attributes.Add("onClick", "BtnClick('MainContent_BT_ShohinDaibunri_Add')");
        //    updShohinDiaPopup.Update();
        //}

        //protected void btn_SyouhinDiaSelect_Click(object sender, EventArgs e)
        //{
        //    if (Session["cSYOUHIN_DAIGRP"] != null)
        //    {
        //        string ctantou = (string)Session["cSYOUHIN_DAIGRP"];
        //        string stantou = (string)Session["sSYOUHIN_DAIGRP"];
        //        if (!String.IsNullOrEmpty(ctantou))
        //        {
        //            lblcSYOUHINDAIGRP.Text = ctantou;
        //            lblsSYOUHINDAIGRP.Text = stantou;
        //            Div_ShohinDaibunri.Style["display"] = "none";
        //            Div_ShohinDaibunriLable.Style["display"] = "block";
        //            divShohinDaibunriSyosai.Style["display"] = "block";

        //            Upd_ShohinDaibunri.Update();
        //            if (Session["cSYOUHIN_TYUUGRP"] == null)
        //            {
        //                lblcSYOUHINTYUUGRP.Text = "";
        //                lblsSYOUHINTYUUGRP.Text = "";
        //                di.Style["display"] = "block";
        //                divChuuLabel.Style["display"] = "none";
        //                Upd_syouhinChuuBunri.Update();
        //            }
        //        }
        //        else
        //        {
        //            BT_ShohinDaibunri_Cross_Click(sender, e);
        //        }
              
        //    }
        //    updHeader.Update();
        //    ifShohinDiaPopup.Src = "";
        //    mpeShohinDiaPopup.Hide();
        //    updsSyouhin.Update();
        //    if (Session["cSYOUHIN_DAIGRP"] != null)
        //    {
        //        string cDAIGRP = (string)Session["cSYOUHIN_DAIGRP"];
        //        string sDAIGRP = (string)Session["sSYOUHIN_DAIGRP"];
        //        lblsSYOUHINDAIGRP.Text = sDAIGRP;
        //        lblcSYOUHINDAIGRP.Text = cDAIGRP;
        //        divDai.Style["display"] = "none";
        //        divDaiLabel.Style["display"] = "block";
        //        Upd_ShohinDaibunri.Update();

        //        if (Session["cSYOUHIN_TYUUGRP"] == null)
        //        {
        //            lblcSYOUHINTYUUGRP.Text = "";
        //            lblsSYOUHINTYUUGRP.Text = "";
        //            divChuu.Style["display"] = "block";
        //            divChuuLabel.Style["display"] = "none";
        //            Upd_syouhinChuuBunri.Update();
        //        }

        //    }
        //    //HF_isChange.Value = "1";
        //    ifDaibunruiPopup.Src = "";
        //    mpeDaibunruiPopup.Hide();
        //    updDaibunruiPopup.Update();
        //}
        //#endregion
        #region BT_ShohinDaibunri_Syousai_Click
        protected void BT_ShohinDaibunri_Syousai_Click(object sender, EventArgs e)
        {
            Session["fSyouhinSyosai"] = "null";
            Session["cSYOUHINDAIGRP"] = lblcSYOUHINDAIGRP.Text;
            //Response.Redirect("JC19TokuisakiSyousai.aspx");
            Response.Write("<script language='javascript'>window.open('JC38Daibunrui.aspx', '_blank');</script>");

        }
        #endregion
        #region BT_ShohinDaibunri_Cross_Click
        protected void BT_ShohinDaibunri_Cross_Click(object sender, EventArgs e)
        {
            Session["cSYOUHIN_DAIGRP"] = null;
            Session["sSYOUHIN_DAIGRP"] = null;
            lblsSYOUHINDAIGRP.Text = "";
            lblcSYOUHINDAIGRP.Text = "";
            Div_ShohinDaibunri.Style["display"] = "block";
            Div_ShohinDaibunriLable.Style["display"] = "none";
            divShohinDaibunriSyosai.Style["display"] = "none";

            updHeader.Update();
        }
        #endregion

        //#region BT_ShohinTyuu_Add_Click
        //protected void BT_ShohinTyuu_Add_Click(object sender, EventArgs e)
        //{
        //    Session["cSYOUHIN_DAIGRP"] = lblcSYOUHINDAIGRP.Text;
        //    Session["sSYOUHIN_DAIGRP"] = lblsSYOUHINDAIGRP.Text;
        //    Session["fSyouhinSyosai"] = "Popup";
        //    SessionUtility.SetSession("HOME", "Master");
        //    //ifShohinTuuPopup.Style["width"] = "440px";
        //    //ifShohinDiaPopup.Style["height"] = "392px";
        //    ifShohinTuuPopup.Src = "JC39Chubunrui.aspx";

        //    mpeShohinTuuPopup.Show();

        //    lblsSYOUHINTYUUGRP.Attributes.Add("onClick", "BtnClick('MainContent_BT_ShohinTyuu_Add')");
        //    updShohinTuuPopup.Update();

        //}
        //protected void btn_ShohinTyuuSelect_Click(object sender, EventArgs e)
        //{
        //    if (Session["cSYOUHIN_TYUUGRP"] != null)
        //    {
        //        string ctantou = (string)Session["cSYOUHIN_TYUUGRP"];
        //        string stantou = (string)Session["sSYOUHIN_TYUUGRP"];
        //        if (!String.IsNullOrEmpty(ctantou))
        //        {
        //            lblcSYOUHINTYUUGRP.Text = ctantou;
        //            lblsSYOUHINTYUUGRP.Text = stantou;
        //            divBT_ShohinTyuu.Style["display"] = "none";
        //            Div_ShohinTyuuLable.Style["display"] = "block";
        //            divShohinTyuuSyousai.Style["display"] = "block";

        //            Upd_SYOUHINTYUUbunri.Update();
        //        }
        //        else
        //        {
        //            BT_ShohinTyuu_Cross_Click(sender, e);
        //        }
        //        //BT_Save.Enabled = true;
        //        //HF_isChange.Value = "1";
               
        //    }
        //    updHeader.Update();
        //    ifShohinDiaPopup.Src = "";
        //    mpeShohinDiaPopup.Hide();
        //    updsSyouhin.Update();

        //}
        //#endregion
        #region BT_ShohinTyuu_Syousai_Click
        protected void BT_ShohinTyuu_Syousai_Click(object sender, EventArgs e)
        {
            Session["fSyouhinSyosai"] = "null";
            Session["cSYOUHINTyuuGRP"] = lblcSYOUHINTYUUGRP.Text;
            //Response.Redirect("JC19TokuisakiSyousai.aspx");
            Response.Write("<script language='javascript'>window.open('JC39Chubunrui.aspx', '_blank');</script>");

        }
        #endregion
        //#region BT_ShohinTyuu_Cross_Click
        //protected void BT_ShohinTyuu_Cross_Click(object sender, EventArgs e)
        //{
        //    Session["cSYOUHIN_TYUUGRP"] = null;
        //    Session["sSYOUHIN_TYUUGRP"] = null;
        //    lblcSYOUHINTYUUGRP.Text = "";
        //    lblsSYOUHINTYUUGRP.Text = "";
        //    divBT_ShohinTyuu.Style["display"] = "block";
        //    Div_ShohinTyuuLable.Style["display"] = "none";
        //    divShohinTyuuSyousai.Style["display"] = "none";

        //    updHeader.Update();
        //}
        //#endregion


        /*----------テテ add 20200321 start-------------*/


        #region BT_ShohinDaibunri_Add_Click
        protected void BT_ShohinDaibunri_Add_Click(object sender, EventArgs e)
        {
            SessionUtility.SetSession("HOME", "Master");
            ifDaibunruiPopup.Style["width"] = "100vw";
            ifDaibunruiPopup.Style["height"] = "100vh";
            ifDaibunruiPopup.Src = "JC38Daibunrui.aspx";
            Session["fDai"] = "true";
            mpeDaibunruiPopup.Show();

            lblsSYOUHINDAIGRP.Attributes.Add("onClick", "BtnClick('MainContent_BT_ShohinDaibunri_Add')");
            updDaibunruiPopup.Update();

        }
        #endregion

        #region btnMasterDaiPopupClose_Click
        protected void btnMasterDaiPopupClose_Click(object sender, EventArgs e)
        {
            Session["fDai"] = "false";
            ifDaibunruiPopup.Src = "";
            mpeDaibunruiPopup.Hide();
            updDaibunruiPopup.Update();

            if (Session["cSYOUHIN_DAIGRP"] == null)
            {
                lblsSYOUHINDAIGRP.Text = "";
                lblcSYOUHINDAIGRP.Text = "";
                Div_ShohinDaibunri.Style["display"] = "block";
                Div_ShohinDaibunriLable.Style["display"] = "none";
                updHeader.Update();
            }
            if (Session["cSYOUHIN_TYUUGRP"] == null)
            {
                lblcSYOUHINTYUUGRP.Text = "";
                lblsSYOUHINTYUUGRP.Text = "";
                divBT_ShohinTyuu.Style["display"] = "block";
                Div_ShohinTyuuLable.Style["display"] = "none";
                updHeader.Update();
            }

        }
        #endregion

        #region btnDaiSelect_Click
        protected void btnDaiSelect_Click(object sender, EventArgs e)
        {
            if (Session["cSYOUHIN_DAIGRP"] != null)
            {
                string cDAIGRP = (string)Session["cSYOUHIN_DAIGRP"];
                string sDAIGRP = (string)Session["sSYOUHIN_DAIGRP"];
                lblsSYOUHINDAIGRP.Text = sDAIGRP;
                lblcSYOUHINDAIGRP.Text = cDAIGRP;
                Div_ShohinDaibunri.Style["display"] = "none";
                Div_ShohinDaibunriLable.Style["display"] = "block";
                Upd_ShohinDaibunri.Update();

                if (Session["cSYOUHIN_TYUUGRP"] == null)
                {
                    lblcSYOUHINTYUUGRP.Text = "";
                    lblsSYOUHINTYUUGRP.Text = "";
                    divBT_ShohinTyuu.Style["display"] = "block";
                    Div_ShohinTyuuLable.Style["display"] = "none";
                    Upd_SYOUHINTYUUbunri.Update();
                }

            }
            //HF_isChange.Value = "1";
            ifDaibunruiPopup.Src = "";
            mpeDaibunruiPopup.Hide();
            updDaibunruiPopup.Update();
            //updHeader.Update();
        }
        #endregion

        #region BT_ShohinTyuu_Cross_Click
        protected void BT_ShohinTyuu_Cross_Click(object sender, EventArgs e)
        {
            Session["shouhin_chuu"] = null;//テテ 20220328
            Session["cSYOUHIN_TYUUGRP"] = null;
            Session["sSYOUHIN_TYUUGRP"] = null;
            lblcSYOUHINTYUUGRP.Text = "";
            lblsSYOUHINTYUUGRP.Text = "";
            divBT_ShohinTyuu.Style["display"] = "block";
            Div_ShohinTyuuLable.Style["display"] = "none";
            divShohinTyuuSyousai.Style["display"] = "none";

            updHeader.Update();
        }
        #endregion

        #region btnMasterChuuPopupClose_Click
        protected void btnMasterChuuPopupClose_Click(object sender, EventArgs e)
        {
            Session["fChuu"] = "false";
            Session["fDoubleChuu"] = "false";
            ifDaibunruiPopup.Src = "";
            mpeDaibunruiPopup.Hide();
            updDaibunruiPopup.Update();

            if (Session["cSYOUHIN_TYUUGRP"] == null)
            {
                Session["cSYOUHIN_TYUUGRP"] = null;
                Session["sSYOUHIN_TYUUGRP"] = null;
                lblcSYOUHINTYUUGRP.Text = "";
                lblsSYOUHINTYUUGRP.Text = "";
                divBT_ShohinTyuu.Style["display"] = "block";
                Div_ShohinTyuuLable.Style["display"] = "none";
                updHeader.Update();
            }
        }
        #endregion

        #region BT_ShohinTyuu_Add_Click
        protected void BT_ShohinTyuu_Add_Click(object sender, EventArgs e)
        {
            SessionUtility.SetSession("HOME", "Master");
            ifDaibunruiPopup.Style["width"] = "100vw";//テテ 20220328
            ifDaibunruiPopup.Style["height"] = "100vh";//700px
            ifDaibunruiPopup.Src = "JC39Chubunrui.aspx";
            Session["fChuu"] = "true";
            mpeDaibunruiPopup.Show();

            lblsSYOUHINTYUUGRP.Attributes.Add("onClick", "BtnClick('MainContent_BT_ShohinTyuu_Add')");
            updDaibunruiPopup.Update();

        }
        #endregion

        #region btnChuuSelect_Click
        protected void btnChuuSelect_Click(object sender, EventArgs e)
        {
            if (Session["cSYOUHIN_TYUUGRP"] != null)
            {
                string cDAIGRP = (string)Session["cSYOUHIN_DAIGRP"];
                string sDAIGRP = (string)Session["sSYOUHIN_DAIGRP"];
                lblsSYOUHINDAIGRP.Text = sDAIGRP;
                lblcSYOUHINDAIGRP.Text = cDAIGRP;
                Div_ShohinDaibunri.Style["display"] = "none";
                Div_ShohinDaibunriLable.Style["display"] = "block";
                Upd_ShohinDaibunri.Update();
                lblsSYOUHINDAIGRP.Attributes.Add("onClick", "BtnClick('MainContent_BT_ShohinDaibunri_Add')");

                string cTYUUGRP = (string)Session["cSYOUHIN_TYUUGRP"];
                string sTYUUGRP = (string)Session["sSYOUHIN_TYUUGRP"];
                lblcSYOUHINTYUUGRP.Text = cTYUUGRP;
                lblsSYOUHINTYUUGRP.Text = sTYUUGRP;

                lblcSYOUHINTYUUGRP.Text = cTYUUGRP;
                lblsSYOUHINTYUUGRP.Text = sTYUUGRP;

                divBT_ShohinTyuu.Style["display"] = "none";
                Div_ShohinTyuuLable.Style["display"] = "block";
                Upd_SYOUHINTYUUbunri.Update();

            }
            Session["fDai"] = false;
            Session["fChuu"] = false;

            if (Session["fDoubleChuu"] != null)
            {
                if (Session["fDoubleChuu"].ToString() == "true")
                {
                    Session["fDoubleChuu"] = null;
                }
            }
            //HF_isChange.Value = "1";
            ifDaibunruiPopup.Src = "";
            mpeDaibunruiPopup.Hide();
            updDaibunruiPopup.Update();
            //updHeader.Update();
        }
        #endregion

        /*----------テテ add 20200321 end-------------*/
        #region BT_SHIIRESAKI_Add_Click 標準仕入先
        protected void BT_SHIIRESAKI_Add_Click(object sender, EventArgs e)
        {
            SessionUtility.SetSession("HOME", "Popup");
            //ifShohinDiaPopup.Style["width"] = "440px";
            //ifShohinDiaPopup.Style["height"] = "392px";
            ifSHIIRESAKIPopup.Src = "JC41ShiiresakiKensaku.aspx";

            mpeSHIIRESAKIPopup.Show();

            lblsSHIIRESAKI.Attributes.Add("onClick", "BtnClick('MainContent_BT_SHIIRESAKI_Add')");
            updSHIIRESAKIKPopup.Update();

        }
        protected void btn_SHIIRESAKISelect_Click(object sender, EventArgs e)
        {
            if (Session["cSHIIRESAKI"] != null)
            {
                string ctantou = (string)Session["cSHIIRESAKI"];
                string stantou = (string)Session["sSHIIRESAKI"];
                if (!String.IsNullOrEmpty(ctantou))
                {
                    
                    lblcSHIIRESAKI.Text = ctantou;
                    lblsSHIIRESAKI.Text = stantou;
                    divSHIIRESAKIKensaku.Style["display"] = "none";
                    divSHIIRESAKIKensakuLabel.Style["display"] = "block";
                    divSHIIRESAKI_Syousai.Style["display"] = "block";

                    upd_SHIIRESAKI.Update();
                }
                else
                {
                    BT_SHIIRESAKI_Cross_Click(sender, e);
                }
                //BT_Save.Enabled = true;
                //HF_isChange.Value = "1";
              //  updHeader.Update();
            }
            updHeader.Update();
            ifSHIIRESAKIPopup.Src = "";
            mpeSHIIRESAKIPopup.Hide();
            updSHIIRESAKIKPopup.Update();
        }

        #endregion
        protected void btn_Close_Click(object sender, EventArgs e)
        {
            ifSHIIRESAKIPopup.Src = "";
            mpeSHIIRESAKIPopup.Hide();
            updSHIIRESAKIKPopup.Update();
            ifDaibunruiPopup.Src = "";//ジイー20220324
            mpeDaibunruiPopup.Hide();//ジイー20220324
            updDaibunruiPopup.Update();//ジイー20220324
        }
        #region BT_SHIIRESAKI_Syousai_Click
        protected void BT_SHIIRESAKI_Syousai_Click(object sender, EventArgs e)
         {
            Session["fSyouhinSyosai"] = "null";
            Session["cSHIIRESAKI"] = lblcSHIIRESAKI.Text;
            Response.Write("<script language='javascript'>window.open('JC40Shiiresaki.aspx', '_blank');</script>");

        }
        #endregion
        #region BT_SHIIRESAKI_Cross_Click
        protected void BT_SHIIRESAKI_Cross_Click(object sender, EventArgs e)
        {
            Session["cSHIIRESAKI"] = null;
            Session["sSHIIRESAKI"] = null;
            lblcSHIIRESAKI.Text = "";
            lblsSHIIRESAKI.Text = "";
            divSHIIRESAKIKensaku.Style["display"] = "block";
            divSHIIRESAKIKensakuLabel.Style["display"] = "none";
            divSHIIRESAKI_Syousai.Style["display"] = "none";

            updHeader.Update();
        }
        #endregion

        #region "X　キャンセルボタン"

        /// <summary>
        /// X　閉じるボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {

            if (Session["fGamen"] != null)
            {
                if (Session["fGamen"].ToString() == "Setting")
                {
                    Session["fGamen"] = null;
                    ScriptManager.RegisterStartupScript(this, GetType(), "CallMyFunction", "parentButtonClick('btn_Close','Master');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "CallMyFunction", "parentButtonClick('btnSyouhinNew_Close','Popup');", true);
            }

        }
        #endregion

    }
}