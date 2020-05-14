namespace Example
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnIfoodCancelamentoRejeita = new System.Windows.Forms.Button();
            this.btnIfoodCancelamentoAceita = new System.Windows.Forms.Button();
            this.btnIfoodCancelamento = new System.Windows.Forms.Button();
            this.btnIfoodRejeitado = new System.Windows.Forms.Button();
            this.btnIfoodSaiuParaSerEntregue = new System.Windows.Forms.Button();
            this.btnIfoodConfirmado = new System.Windows.Forms.Button();
            this.btnIfoodIntegrado = new System.Windows.Forms.Button();
            this.gridIfood = new System.Windows.Forms.DataGridView();
            this.btnIfoodParar = new System.Windows.Forms.Button();
            this.btnIfoodIniciar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtIfoodSenha = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIfoodUsuario = new System.Windows.Forms.TextBox();
            this.txtIfoodMerchantId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtIfoodClient_Secret = new System.Windows.Forms.TextBox();
            this.txtIfoodClient_ID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnGloriaFoodMenu = new System.Windows.Forms.Button();
            this.gridGloriaGood = new System.Windows.Forms.DataGridView();
            this.txtGloriaFoodToken = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnGloriaFoodParar = new System.Windows.Forms.Button();
            this.btnGloriaFoodIniciar = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.gridSuperMenu = new System.Windows.Forms.DataGridView();
            this.txtSuperMenuToken = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSuperMenuParar = new System.Windows.Forms.Button();
            this.btnSuperMenuIniciar = new System.Windows.Forms.Button();
            this.btnSuperMenuCancelar = new System.Windows.Forms.Button();
            this.btnSuperMenuRejeitar = new System.Windows.Forms.Button();
            this.btnSuperMenuSaiuParaSerEntregue = new System.Windows.Forms.Button();
            this.btnSuperMenuConfirmar = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridIfood)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridGloriaGood)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSuperMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1237, 711);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnIfoodCancelamentoRejeita);
            this.tabPage1.Controls.Add(this.btnIfoodCancelamentoAceita);
            this.tabPage1.Controls.Add(this.btnIfoodCancelamento);
            this.tabPage1.Controls.Add(this.btnIfoodRejeitado);
            this.tabPage1.Controls.Add(this.btnIfoodSaiuParaSerEntregue);
            this.tabPage1.Controls.Add(this.btnIfoodConfirmado);
            this.tabPage1.Controls.Add(this.btnIfoodIntegrado);
            this.tabPage1.Controls.Add(this.gridIfood);
            this.tabPage1.Controls.Add(this.btnIfoodParar);
            this.tabPage1.Controls.Add(this.btnIfoodIniciar);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1229, 685);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ifood";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnIfoodCancelamentoRejeita
            // 
            this.btnIfoodCancelamentoRejeita.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIfoodCancelamentoRejeita.Location = new System.Drawing.Point(998, 139);
            this.btnIfoodCancelamentoRejeita.Name = "btnIfoodCancelamentoRejeita";
            this.btnIfoodCancelamentoRejeita.Size = new System.Drawing.Size(175, 33);
            this.btnIfoodCancelamentoRejeita.TabIndex = 11;
            this.btnIfoodCancelamentoRejeita.Text = "Rejeita Cancelamento";
            this.btnIfoodCancelamentoRejeita.UseVisualStyleBackColor = true;
            this.btnIfoodCancelamentoRejeita.Click += new System.EventHandler(this.btnIfoodCancelamentoRejeita_Click);
            // 
            // btnIfoodCancelamentoAceita
            // 
            this.btnIfoodCancelamentoAceita.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIfoodCancelamentoAceita.Location = new System.Drawing.Point(817, 139);
            this.btnIfoodCancelamentoAceita.Name = "btnIfoodCancelamentoAceita";
            this.btnIfoodCancelamentoAceita.Size = new System.Drawing.Size(175, 33);
            this.btnIfoodCancelamentoAceita.TabIndex = 10;
            this.btnIfoodCancelamentoAceita.Text = "Aceita Cancelamento";
            this.btnIfoodCancelamentoAceita.UseVisualStyleBackColor = true;
            this.btnIfoodCancelamentoAceita.Click += new System.EventHandler(this.btnIfoodCancelamentoAceita_Click);
            // 
            // btnIfoodCancelamento
            // 
            this.btnIfoodCancelamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIfoodCancelamento.Location = new System.Drawing.Point(666, 139);
            this.btnIfoodCancelamento.Name = "btnIfoodCancelamento";
            this.btnIfoodCancelamento.Size = new System.Drawing.Size(145, 33);
            this.btnIfoodCancelamento.TabIndex = 9;
            this.btnIfoodCancelamento.Text = "Cancelamento";
            this.btnIfoodCancelamento.UseVisualStyleBackColor = true;
            this.btnIfoodCancelamento.Click += new System.EventHandler(this.btnIfoodCancelamento_Click);
            // 
            // btnIfoodRejeitado
            // 
            this.btnIfoodRejeitado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIfoodRejeitado.Location = new System.Drawing.Point(515, 139);
            this.btnIfoodRejeitado.Name = "btnIfoodRejeitado";
            this.btnIfoodRejeitado.Size = new System.Drawing.Size(145, 33);
            this.btnIfoodRejeitado.TabIndex = 8;
            this.btnIfoodRejeitado.Text = "Rejeitado";
            this.btnIfoodRejeitado.UseVisualStyleBackColor = true;
            this.btnIfoodRejeitado.Click += new System.EventHandler(this.btnIfoodRejeitado_Click);
            // 
            // btnIfoodSaiuParaSerEntregue
            // 
            this.btnIfoodSaiuParaSerEntregue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIfoodSaiuParaSerEntregue.Location = new System.Drawing.Point(310, 139);
            this.btnIfoodSaiuParaSerEntregue.Name = "btnIfoodSaiuParaSerEntregue";
            this.btnIfoodSaiuParaSerEntregue.Size = new System.Drawing.Size(199, 33);
            this.btnIfoodSaiuParaSerEntregue.TabIndex = 7;
            this.btnIfoodSaiuParaSerEntregue.Text = "Saiu para ser entregue";
            this.btnIfoodSaiuParaSerEntregue.UseVisualStyleBackColor = true;
            this.btnIfoodSaiuParaSerEntregue.Click += new System.EventHandler(this.btnIfoodSaiuParaSerEntregue_Click);
            // 
            // btnIfoodConfirmado
            // 
            this.btnIfoodConfirmado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIfoodConfirmado.Location = new System.Drawing.Point(159, 139);
            this.btnIfoodConfirmado.Name = "btnIfoodConfirmado";
            this.btnIfoodConfirmado.Size = new System.Drawing.Size(145, 33);
            this.btnIfoodConfirmado.TabIndex = 6;
            this.btnIfoodConfirmado.Text = "Confirmado";
            this.btnIfoodConfirmado.UseVisualStyleBackColor = true;
            this.btnIfoodConfirmado.Click += new System.EventHandler(this.btnIfoodConfirmado_Click);
            // 
            // btnIfoodIntegrado
            // 
            this.btnIfoodIntegrado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIfoodIntegrado.Location = new System.Drawing.Point(8, 139);
            this.btnIfoodIntegrado.Name = "btnIfoodIntegrado";
            this.btnIfoodIntegrado.Size = new System.Drawing.Size(145, 33);
            this.btnIfoodIntegrado.TabIndex = 5;
            this.btnIfoodIntegrado.Text = "Integrado";
            this.btnIfoodIntegrado.UseVisualStyleBackColor = true;
            this.btnIfoodIntegrado.Click += new System.EventHandler(this.btnIfoodIntegrado_Click);
            // 
            // gridIfood
            // 
            this.gridIfood.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridIfood.Location = new System.Drawing.Point(8, 178);
            this.gridIfood.Name = "gridIfood";
            this.gridIfood.Size = new System.Drawing.Size(1213, 487);
            this.gridIfood.TabIndex = 4;
            this.gridIfood.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridIfood_CellClick);
            // 
            // btnIfoodParar
            // 
            this.btnIfoodParar.Enabled = false;
            this.btnIfoodParar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIfoodParar.Location = new System.Drawing.Point(1050, 67);
            this.btnIfoodParar.Name = "btnIfoodParar";
            this.btnIfoodParar.Size = new System.Drawing.Size(171, 39);
            this.btnIfoodParar.TabIndex = 3;
            this.btnIfoodParar.Text = "Parar";
            this.btnIfoodParar.UseVisualStyleBackColor = true;
            this.btnIfoodParar.Click += new System.EventHandler(this.btnIfoodParar_Click);
            // 
            // btnIfoodIniciar
            // 
            this.btnIfoodIniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIfoodIniciar.Location = new System.Drawing.Point(1050, 16);
            this.btnIfoodIniciar.Name = "btnIfoodIniciar";
            this.btnIfoodIniciar.Size = new System.Drawing.Size(171, 39);
            this.btnIfoodIniciar.TabIndex = 2;
            this.btnIfoodIniciar.Text = "Iniciar";
            this.btnIfoodIniciar.UseVisualStyleBackColor = true;
            this.btnIfoodIniciar.Click += new System.EventHandler(this.btnIfoodIniciar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtIfoodSenha);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtIfoodUsuario);
            this.groupBox2.Controls.Add(this.txtIfoodMerchantId);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(376, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(651, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Restaurante";
            // 
            // txtIfoodSenha
            // 
            this.txtIfoodSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIfoodSenha.Location = new System.Drawing.Point(452, 55);
            this.txtIfoodSenha.Name = "txtIfoodSenha";
            this.txtIfoodSenha.Size = new System.Drawing.Size(187, 26);
            this.txtIfoodSenha.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(359, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Senha";
            // 
            // txtIfoodUsuario
            // 
            this.txtIfoodUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIfoodUsuario.Location = new System.Drawing.Point(452, 19);
            this.txtIfoodUsuario.Name = "txtIfoodUsuario";
            this.txtIfoodUsuario.Size = new System.Drawing.Size(187, 26);
            this.txtIfoodUsuario.TabIndex = 7;
            // 
            // txtIfoodMerchantId
            // 
            this.txtIfoodMerchantId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIfoodMerchantId.Location = new System.Drawing.Point(155, 19);
            this.txtIfoodMerchantId.Name = "txtIfoodMerchantId";
            this.txtIfoodMerchantId.Size = new System.Drawing.Size(187, 26);
            this.txtIfoodMerchantId.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "MerchantId";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(359, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Usuario";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtIfoodClient_Secret);
            this.groupBox1.Controls.Add(this.txtIfoodClient_ID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Software House";
            // 
            // txtIfoodClient_Secret
            // 
            this.txtIfoodClient_Secret.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIfoodClient_Secret.Location = new System.Drawing.Point(151, 55);
            this.txtIfoodClient_Secret.Name = "txtIfoodClient_Secret";
            this.txtIfoodClient_Secret.Size = new System.Drawing.Size(187, 26);
            this.txtIfoodClient_Secret.TabIndex = 3;
            // 
            // txtIfoodClient_ID
            // 
            this.txtIfoodClient_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIfoodClient_ID.Location = new System.Drawing.Point(151, 23);
            this.txtIfoodClient_ID.Name = "txtIfoodClient_ID";
            this.txtIfoodClient_ID.Size = new System.Drawing.Size(187, 26);
            this.txtIfoodClient_ID.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "CLIENT_SECRET";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "CLIENT_ID";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnGloriaFoodMenu);
            this.tabPage2.Controls.Add(this.gridGloriaGood);
            this.tabPage2.Controls.Add(this.txtGloriaFoodToken);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.btnGloriaFoodParar);
            this.tabPage2.Controls.Add(this.btnGloriaFoodIniciar);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1229, 685);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Gloria Food";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnGloriaFoodMenu
            // 
            this.btnGloriaFoodMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGloriaFoodMenu.Location = new System.Drawing.Point(12, 68);
            this.btnGloriaFoodMenu.Name = "btnGloriaFoodMenu";
            this.btnGloriaFoodMenu.Size = new System.Drawing.Size(171, 39);
            this.btnGloriaFoodMenu.TabIndex = 9;
            this.btnGloriaFoodMenu.Text = "Buscar Menu";
            this.btnGloriaFoodMenu.UseVisualStyleBackColor = true;
            this.btnGloriaFoodMenu.Click += new System.EventHandler(this.btnGloriaFoodMenu_Click);
            // 
            // gridGloriaGood
            // 
            this.gridGloriaGood.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridGloriaGood.Location = new System.Drawing.Point(12, 113);
            this.gridGloriaGood.Name = "gridGloriaGood";
            this.gridGloriaGood.Size = new System.Drawing.Size(1209, 551);
            this.gridGloriaGood.TabIndex = 8;
            // 
            // txtGloriaFoodToken
            // 
            this.txtGloriaFoodToken.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGloriaFoodToken.Location = new System.Drawing.Point(128, 22);
            this.txtGloriaFoodToken.Name = "txtGloriaFoodToken";
            this.txtGloriaFoodToken.Size = new System.Drawing.Size(291, 26);
            this.txtGloriaFoodToken.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "TOKEN";
            // 
            // btnGloriaFoodParar
            // 
            this.btnGloriaFoodParar.Enabled = false;
            this.btnGloriaFoodParar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGloriaFoodParar.Location = new System.Drawing.Point(1050, 57);
            this.btnGloriaFoodParar.Name = "btnGloriaFoodParar";
            this.btnGloriaFoodParar.Size = new System.Drawing.Size(171, 39);
            this.btnGloriaFoodParar.TabIndex = 5;
            this.btnGloriaFoodParar.Text = "Parar";
            this.btnGloriaFoodParar.UseVisualStyleBackColor = true;
            this.btnGloriaFoodParar.Click += new System.EventHandler(this.btnGloriaFoodParar_Click);
            // 
            // btnGloriaFoodIniciar
            // 
            this.btnGloriaFoodIniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGloriaFoodIniciar.Location = new System.Drawing.Point(1050, 6);
            this.btnGloriaFoodIniciar.Name = "btnGloriaFoodIniciar";
            this.btnGloriaFoodIniciar.Size = new System.Drawing.Size(171, 39);
            this.btnGloriaFoodIniciar.TabIndex = 4;
            this.btnGloriaFoodIniciar.Text = "Iniciar";
            this.btnGloriaFoodIniciar.UseVisualStyleBackColor = true;
            this.btnGloriaFoodIniciar.Click += new System.EventHandler(this.btnGloriaFoodIniciar_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnSuperMenuCancelar);
            this.tabPage3.Controls.Add(this.btnSuperMenuRejeitar);
            this.tabPage3.Controls.Add(this.btnSuperMenuSaiuParaSerEntregue);
            this.tabPage3.Controls.Add(this.btnSuperMenuConfirmar);
            this.tabPage3.Controls.Add(this.gridSuperMenu);
            this.tabPage3.Controls.Add(this.txtSuperMenuToken);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.btnSuperMenuParar);
            this.tabPage3.Controls.Add(this.btnSuperMenuIniciar);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1229, 685);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Super Menu";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // gridSuperMenu
            // 
            this.gridSuperMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSuperMenu.Location = new System.Drawing.Point(12, 120);
            this.gridSuperMenu.Name = "gridSuperMenu";
            this.gridSuperMenu.Size = new System.Drawing.Size(1209, 551);
            this.gridSuperMenu.TabIndex = 14;
            this.gridSuperMenu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridSuperMenu_CellClick);
            // 
            // txtSuperMenuToken
            // 
            this.txtSuperMenuToken.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSuperMenuToken.Location = new System.Drawing.Point(128, 29);
            this.txtSuperMenuToken.Name = "txtSuperMenuToken";
            this.txtSuperMenuToken.Size = new System.Drawing.Size(291, 26);
            this.txtSuperMenuToken.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "TOKEN";
            // 
            // btnSuperMenuParar
            // 
            this.btnSuperMenuParar.Enabled = false;
            this.btnSuperMenuParar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuperMenuParar.Location = new System.Drawing.Point(1050, 64);
            this.btnSuperMenuParar.Name = "btnSuperMenuParar";
            this.btnSuperMenuParar.Size = new System.Drawing.Size(171, 39);
            this.btnSuperMenuParar.TabIndex = 11;
            this.btnSuperMenuParar.Text = "Parar";
            this.btnSuperMenuParar.UseVisualStyleBackColor = true;
            this.btnSuperMenuParar.Click += new System.EventHandler(this.btnSuperMenuParar_Click);
            // 
            // btnSuperMenuIniciar
            // 
            this.btnSuperMenuIniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuperMenuIniciar.Location = new System.Drawing.Point(1050, 13);
            this.btnSuperMenuIniciar.Name = "btnSuperMenuIniciar";
            this.btnSuperMenuIniciar.Size = new System.Drawing.Size(171, 39);
            this.btnSuperMenuIniciar.TabIndex = 10;
            this.btnSuperMenuIniciar.Text = "Iniciar";
            this.btnSuperMenuIniciar.UseVisualStyleBackColor = true;
            this.btnSuperMenuIniciar.Click += new System.EventHandler(this.btnSuperMenuIniciar_Click);
            // 
            // btnSuperMenuCancelar
            // 
            this.btnSuperMenuCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuperMenuCancelar.Location = new System.Drawing.Point(519, 81);
            this.btnSuperMenuCancelar.Name = "btnSuperMenuCancelar";
            this.btnSuperMenuCancelar.Size = new System.Drawing.Size(145, 33);
            this.btnSuperMenuCancelar.TabIndex = 18;
            this.btnSuperMenuCancelar.Text = "Cancelar";
            this.btnSuperMenuCancelar.UseVisualStyleBackColor = true;
            this.btnSuperMenuCancelar.Click += new System.EventHandler(this.btnSuperMenuCancelar_Click);
            // 
            // btnSuperMenuRejeitar
            // 
            this.btnSuperMenuRejeitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuperMenuRejeitar.Location = new System.Drawing.Point(368, 81);
            this.btnSuperMenuRejeitar.Name = "btnSuperMenuRejeitar";
            this.btnSuperMenuRejeitar.Size = new System.Drawing.Size(145, 33);
            this.btnSuperMenuRejeitar.TabIndex = 17;
            this.btnSuperMenuRejeitar.Text = "Rejeitar";
            this.btnSuperMenuRejeitar.UseVisualStyleBackColor = true;
            this.btnSuperMenuRejeitar.Click += new System.EventHandler(this.btnSuperMenuRejeitar_Click);
            // 
            // btnSuperMenuSaiuParaSerEntregue
            // 
            this.btnSuperMenuSaiuParaSerEntregue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuperMenuSaiuParaSerEntregue.Location = new System.Drawing.Point(163, 81);
            this.btnSuperMenuSaiuParaSerEntregue.Name = "btnSuperMenuSaiuParaSerEntregue";
            this.btnSuperMenuSaiuParaSerEntregue.Size = new System.Drawing.Size(199, 33);
            this.btnSuperMenuSaiuParaSerEntregue.TabIndex = 16;
            this.btnSuperMenuSaiuParaSerEntregue.Text = "Saiu para ser entregue";
            this.btnSuperMenuSaiuParaSerEntregue.UseVisualStyleBackColor = true;
            this.btnSuperMenuSaiuParaSerEntregue.Click += new System.EventHandler(this.btnSuperMenuSaiuParaSerEntregue_Click);
            // 
            // btnSuperMenuConfirmar
            // 
            this.btnSuperMenuConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuperMenuConfirmar.Location = new System.Drawing.Point(12, 81);
            this.btnSuperMenuConfirmar.Name = "btnSuperMenuConfirmar";
            this.btnSuperMenuConfirmar.Size = new System.Drawing.Size(145, 33);
            this.btnSuperMenuConfirmar.TabIndex = 15;
            this.btnSuperMenuConfirmar.Text = "Confirmar";
            this.btnSuperMenuConfirmar.UseVisualStyleBackColor = true;
            this.btnSuperMenuConfirmar.Click += new System.EventHandler(this.btnSuperMenuConfirmar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 711);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MarketPlace";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridIfood)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridGloriaGood)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSuperMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtIfoodUsuario;
        private System.Windows.Forms.TextBox txtIfoodMerchantId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtIfoodClient_Secret;
        private System.Windows.Forms.TextBox txtIfoodClient_ID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIfoodSenha;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnIfoodParar;
        private System.Windows.Forms.Button btnIfoodIniciar;
        private System.Windows.Forms.Button btnIfoodIntegrado;
        private System.Windows.Forms.DataGridView gridIfood;
        private System.Windows.Forms.Button btnIfoodCancelamentoRejeita;
        private System.Windows.Forms.Button btnIfoodCancelamentoAceita;
        private System.Windows.Forms.Button btnIfoodCancelamento;
        private System.Windows.Forms.Button btnIfoodRejeitado;
        private System.Windows.Forms.Button btnIfoodSaiuParaSerEntregue;
        private System.Windows.Forms.Button btnIfoodConfirmado;
        private System.Windows.Forms.TextBox txtGloriaFoodToken;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnGloriaFoodParar;
        private System.Windows.Forms.Button btnGloriaFoodIniciar;
        private System.Windows.Forms.DataGridView gridGloriaGood;
        private System.Windows.Forms.Button btnGloriaFoodMenu;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView gridSuperMenu;
        private System.Windows.Forms.TextBox txtSuperMenuToken;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSuperMenuParar;
        private System.Windows.Forms.Button btnSuperMenuIniciar;
        private System.Windows.Forms.Button btnSuperMenuCancelar;
        private System.Windows.Forms.Button btnSuperMenuRejeitar;
        private System.Windows.Forms.Button btnSuperMenuSaiuParaSerEntregue;
        private System.Windows.Forms.Button btnSuperMenuConfirmar;
    }
}

