﻿namespace Accounting.Desktop
{
    partial class MainApplication
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.labelIncome = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelPersonalExpense = new System.Windows.Forms.Label();
            this.labelGeneralExpense = new System.Windows.Forms.Label();
            this.dataViewTransactionPE = new System.Windows.Forms.DataGridView();
            this.labelBalanceOverview = new System.Windows.Forms.Label();
            this.dataViewTransactionInc = new System.Windows.Forms.DataGridView();
            this.dataViewTransactionGE = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.labelBalanceTransaction = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataViewTransaction = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewTransactionPE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewTransactionInc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewTransactionGE)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewTransaction)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.button3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(160, 619);
            this.panel1.TabIndex = 25;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button3.Location = new System.Drawing.Point(18, 574);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(128, 27);
            this.button3.TabIndex = 3;
            this.button3.Text = "Shut down";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.Shutdown_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Location = new System.Drawing.Point(166, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1011, 619);
            this.tabControl2.TabIndex = 27;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.tabControl1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1003, 593);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "Transactions";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(-4, 11);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1011, 586);
            this.tabControl1.TabIndex = 27;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.labelIncome);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.labelPersonalExpense);
            this.tabPage1.Controls.Add(this.labelGeneralExpense);
            this.tabPage1.Controls.Add(this.dataViewTransactionPE);
            this.tabPage1.Controls.Add(this.labelBalanceOverview);
            this.tabPage1.Controls.Add(this.dataViewTransactionInc);
            this.tabPage1.Controls.Add(this.dataViewTransactionGE);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1003, 560);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Overview";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // labelIncome
            // 
            this.labelIncome.AutoSize = true;
            this.labelIncome.Location = new System.Drawing.Point(901, 496);
            this.labelIncome.Name = "labelIncome";
            this.labelIncome.Size = new System.Drawing.Size(49, 13);
            this.labelIncome.TabIndex = 40;
            this.labelIncome.Text = "Subtotal:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(515, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "Income";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 290);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Personal Expenses";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "General Expenses";
            // 
            // labelPersonalExpense
            // 
            this.labelPersonalExpense.AutoSize = true;
            this.labelPersonalExpense.Location = new System.Drawing.Point(405, 496);
            this.labelPersonalExpense.Name = "labelPersonalExpense";
            this.labelPersonalExpense.Size = new System.Drawing.Size(49, 13);
            this.labelPersonalExpense.TabIndex = 36;
            this.labelPersonalExpense.Text = "Subtotal:";
            // 
            // labelGeneralExpense
            // 
            this.labelGeneralExpense.AutoSize = true;
            this.labelGeneralExpense.Location = new System.Drawing.Point(405, 273);
            this.labelGeneralExpense.Name = "labelGeneralExpense";
            this.labelGeneralExpense.Size = new System.Drawing.Size(52, 13);
            this.labelGeneralExpense.TabIndex = 35;
            this.labelGeneralExpense.Text = "Subtotal: ";
            // 
            // dataViewTransactionPE
            // 
            this.dataViewTransactionPE.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataViewTransactionPE.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataViewTransactionPE.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataViewTransactionPE.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataViewTransactionPE.BackgroundColor = System.Drawing.Color.White;
            this.dataViewTransactionPE.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataViewTransactionPE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataViewTransactionPE.Location = new System.Drawing.Point(24, 306);
            this.dataViewTransactionPE.Name = "dataViewTransactionPE";
            this.dataViewTransactionPE.ReadOnly = true;
            this.dataViewTransactionPE.RowHeadersVisible = false;
            this.dataViewTransactionPE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataViewTransactionPE.Size = new System.Drawing.Size(465, 187);
            this.dataViewTransactionPE.TabIndex = 34;
            // 
            // labelBalanceOverview
            // 
            this.labelBalanceOverview.AutoSize = true;
            this.labelBalanceOverview.Location = new System.Drawing.Point(21, 527);
            this.labelBalanceOverview.Name = "labelBalanceOverview";
            this.labelBalanceOverview.Size = new System.Drawing.Size(52, 13);
            this.labelBalanceOverview.TabIndex = 33;
            this.labelBalanceOverview.Text = "Balance: ";
            // 
            // dataViewTransactionInc
            // 
            this.dataViewTransactionInc.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataViewTransactionInc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataViewTransactionInc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataViewTransactionInc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataViewTransactionInc.BackgroundColor = System.Drawing.Color.White;
            this.dataViewTransactionInc.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataViewTransactionInc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataViewTransactionInc.Location = new System.Drawing.Point(518, 29);
            this.dataViewTransactionInc.Name = "dataViewTransactionInc";
            this.dataViewTransactionInc.ReadOnly = true;
            this.dataViewTransactionInc.RowHeadersVisible = false;
            this.dataViewTransactionInc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataViewTransactionInc.Size = new System.Drawing.Size(465, 464);
            this.dataViewTransactionInc.TabIndex = 31;
            // 
            // dataViewTransactionGE
            // 
            this.dataViewTransactionGE.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataViewTransactionGE.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataViewTransactionGE.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataViewTransactionGE.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataViewTransactionGE.BackgroundColor = System.Drawing.Color.White;
            this.dataViewTransactionGE.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataViewTransactionGE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataViewTransactionGE.Location = new System.Drawing.Point(24, 29);
            this.dataViewTransactionGE.Name = "dataViewTransactionGE";
            this.dataViewTransactionGE.ReadOnly = true;
            this.dataViewTransactionGE.RowHeadersVisible = false;
            this.dataViewTransactionGE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataViewTransactionGE.Size = new System.Drawing.Size(465, 241);
            this.dataViewTransactionGE.TabIndex = 27;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.labelBalanceTransaction);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.dataViewTransaction);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1003, 560);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Transaction History";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // labelBalanceTransaction
            // 
            this.labelBalanceTransaction.AutoSize = true;
            this.labelBalanceTransaction.Location = new System.Drawing.Point(199, 527);
            this.labelBalanceTransaction.Name = "labelBalanceTransaction";
            this.labelBalanceTransaction.Size = new System.Drawing.Size(52, 13);
            this.labelBalanceTransaction.TabIndex = 34;
            this.labelBalanceTransaction.Text = "Balance: ";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(34, 39);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(148, 23);
            this.button2.TabIndex = 31;
            this.button2.Text = "Withdraw";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Withdraw_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(34, 68);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 23);
            this.button1.TabIndex = 30;
            this.button1.Text = "Deposit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Deposit_Click);
            // 
            // dataViewTransaction
            // 
            this.dataViewTransaction.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataViewTransaction.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataViewTransaction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataViewTransaction.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataViewTransaction.BackgroundColor = System.Drawing.Color.White;
            this.dataViewTransaction.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataViewTransaction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataViewTransaction.Location = new System.Drawing.Point(202, 39);
            this.dataViewTransaction.Name = "dataViewTransaction";
            this.dataViewTransaction.ReadOnly = true;
            this.dataViewTransaction.RowHeadersVisible = false;
            this.dataViewTransaction.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataViewTransaction.Size = new System.Drawing.Size(775, 479);
            this.dataViewTransaction.TabIndex = 28;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridView2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1003, 560);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "General Expense";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(269, 39);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(465, 481);
            this.dataGridView2.TabIndex = 32;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dataGridView3);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1003, 560);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Personal Expense";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView3.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView3.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView3.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(269, 39);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.RowHeadersVisible = false;
            this.dataGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView3.Size = new System.Drawing.Size(465, 481);
            this.dataGridView3.TabIndex = 32;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.dataGridView4);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1003, 593);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "Accounts";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // dataGridView4
            // 
            this.dataGridView4.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView4.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView4.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView4.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Location = new System.Drawing.Point(269, 72);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.ReadOnly = true;
            this.dataGridView4.RowHeadersVisible = false;
            this.dataGridView4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView4.Size = new System.Drawing.Size(465, 481);
            this.dataGridView4.TabIndex = 29;
            // 
            // MainApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1175, 619);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainApplication";
            this.Text = "Accounting";
            this.panel1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewTransactionPE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewTransactionInc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewTransactionGE)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewTransaction)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataViewTransactionInc;
        private System.Windows.Forms.DataGridView dataViewTransactionGE;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataViewTransaction;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.Label labelBalanceOverview;
        private System.Windows.Forms.DataGridView dataViewTransactionPE;
        private System.Windows.Forms.Label labelPersonalExpense;
        private System.Windows.Forms.Label labelGeneralExpense;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelIncome;
        private System.Windows.Forms.Label labelBalanceTransaction;
    }
}

