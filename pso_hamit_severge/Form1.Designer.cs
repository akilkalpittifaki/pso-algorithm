namespace pso_hamit_severge
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainerMain = new SplitContainer();
            panelLeft = new Panel();
            groupBoxParameters = new GroupBox();
            numMaxX = new NumericUpDown();
            lblMaxX = new Label();
            numMinX = new NumericUpDown();
            lblMinX = new Label();
            numVMax = new NumericUpDown();
            lblVMax = new Label();
            numC2 = new NumericUpDown();
            lblC2 = new Label();
            numC1 = new NumericUpDown();
            lblC1 = new Label();
            numMaxIterations = new NumericUpDown();
            lblMaxIterations = new Label();
            numDimension = new NumericUpDown();
            lblDimension = new Label();
            numParticleCount = new NumericUpDown();
            lblParticleCount = new Label();
            btnStart = new Button();
            txtResult = new TextBox();
            lblResults = new Label();
            lblChart = new Label();
            chartConvergence = new System.Windows.Forms.DataVisualization.Charting.Chart();
            panelRight = new Panel();
            lblAlgorithmDescription = new Label();
            txtAlgorithmDescription = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            panelLeft.SuspendLayout();
            groupBoxParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numMaxX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMinX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numVMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numC2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numC1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMaxIterations).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDimension).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numParticleCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartConvergence).BeginInit();
            panelRight.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainerMain
            // 
            splitContainerMain.Dock = DockStyle.Fill;
            splitContainerMain.Location = new Point(0, 0);
            splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            splitContainerMain.Panel1.Controls.Add(panelLeft);
            splitContainerMain.Panel1MinSize = 700;
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.Controls.Add(panelRight);
            splitContainerMain.Panel2MinSize = 300;
            splitContainerMain.Size = new Size(1200, 600);
            splitContainerMain.SplitterDistance = 896;
            splitContainerMain.TabIndex = 0;
            // 
            // panelLeft
            // 
            panelLeft.Controls.Add(groupBoxParameters);
            panelLeft.Controls.Add(btnStart);
            panelLeft.Controls.Add(chartConvergence);
            panelLeft.Controls.Add(txtResult);
            panelLeft.Controls.Add(lblResults);
            panelLeft.Controls.Add(lblChart);
            panelLeft.Dock = DockStyle.Fill;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(896, 600);
            panelLeft.TabIndex = 0;
            // 
            // groupBoxParameters
            // 
            groupBoxParameters.Controls.Add(numMaxX);
            groupBoxParameters.Controls.Add(lblMaxX);
            groupBoxParameters.Controls.Add(numMinX);
            groupBoxParameters.Controls.Add(lblMinX);
            groupBoxParameters.Controls.Add(numVMax);
            groupBoxParameters.Controls.Add(lblVMax);
            groupBoxParameters.Controls.Add(numC2);
            groupBoxParameters.Controls.Add(lblC2);
            groupBoxParameters.Controls.Add(numC1);
            groupBoxParameters.Controls.Add(lblC1);
            groupBoxParameters.Controls.Add(numMaxIterations);
            groupBoxParameters.Controls.Add(lblMaxIterations);
            groupBoxParameters.Controls.Add(numDimension);
            groupBoxParameters.Controls.Add(lblDimension);
            groupBoxParameters.Controls.Add(numParticleCount);
            groupBoxParameters.Controls.Add(lblParticleCount);
            groupBoxParameters.Location = new Point(12, 12);
            groupBoxParameters.Name = "groupBoxParameters";
            groupBoxParameters.Size = new Size(278, 291);
            groupBoxParameters.TabIndex = 0;
            groupBoxParameters.TabStop = false;
            groupBoxParameters.Text = "Kontrol Parametreleri";
            // 
            // numMaxX
            // 
            numMaxX.DecimalPlaces = 2;
            numMaxX.Location = new Point(155, 238);
            numMaxX.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numMaxX.Name = "numMaxX";
            numMaxX.Size = new Size(100, 23);
            numMaxX.TabIndex = 15;
            numMaxX.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // lblMaxX
            // 
            lblMaxX.AutoSize = true;
            lblMaxX.Location = new Point(10, 240);
            lblMaxX.Name = "lblMaxX";
            lblMaxX.Size = new Size(152, 15);
            lblMaxX.TabIndex = 14;
            lblMaxX.Text = "Maximum Değer (Üst Sınır):";
            // 
            // numMinX
            // 
            numMinX.DecimalPlaces = 2;
            numMinX.Location = new Point(155, 208);
            numMinX.Maximum = new decimal(new int[] { 0, 0, 0, 0 });
            numMinX.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
            numMinX.Name = "numMinX";
            numMinX.Size = new Size(100, 23);
            numMinX.TabIndex = 13;
            numMinX.Value = new decimal(new int[] { 5, 0, 0, int.MinValue });
            // 
            // lblMinX
            // 
            lblMinX.AutoSize = true;
            lblMinX.Location = new Point(10, 210);
            lblMinX.Name = "lblMinX";
            lblMinX.Size = new Size(149, 15);
            lblMinX.TabIndex = 12;
            lblMinX.Text = "Minimum Değer (Alt Sınır):";
            // 
            // numVMax
            // 
            numVMax.DecimalPlaces = 2;
            numVMax.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numVMax.Location = new Point(155, 178);
            numVMax.Name = "numVMax";
            numVMax.Size = new Size(100, 23);
            numVMax.TabIndex = 11;
            numVMax.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblVMax
            // 
            lblVMax.AutoSize = true;
            lblVMax.Location = new Point(10, 180);
            lblVMax.Name = "lblVMax";
            lblVMax.Size = new Size(39, 15);
            lblVMax.TabIndex = 10;
            lblVMax.Text = "VMax:";
            // 
            // numC2
            // 
            numC2.DecimalPlaces = 2;
            numC2.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numC2.Location = new Point(155, 148);
            numC2.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numC2.Name = "numC2";
            numC2.Size = new Size(100, 23);
            numC2.TabIndex = 9;
            numC2.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // lblC2
            // 
            lblC2.AutoSize = true;
            lblC2.Location = new Point(10, 150);
            lblC2.Name = "lblC2";
            lblC2.Size = new Size(126, 15);
            lblC2.TabIndex = 8;
            lblC2.Text = "Öğrenme Faktörü (c2):";
            // 
            // numC1
            // 
            numC1.DecimalPlaces = 2;
            numC1.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numC1.Location = new Point(155, 118);
            numC1.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numC1.Name = "numC1";
            numC1.Size = new Size(100, 23);
            numC1.TabIndex = 7;
            numC1.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // lblC1
            // 
            lblC1.AutoSize = true;
            lblC1.Location = new Point(10, 120);
            lblC1.Name = "lblC1";
            lblC1.Size = new Size(126, 15);
            lblC1.TabIndex = 6;
            lblC1.Text = "Öğrenme Faktörü (c1):";
            // 
            // numMaxIterations
            // 
            numMaxIterations.Location = new Point(155, 88);
            numMaxIterations.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numMaxIterations.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numMaxIterations.Name = "numMaxIterations";
            numMaxIterations.Size = new Size(100, 23);
            numMaxIterations.TabIndex = 5;
            numMaxIterations.Value = new decimal(new int[] { 200, 0, 0, 0 });
            // 
            // lblMaxIterations
            // 
            lblMaxIterations.AutoSize = true;
            lblMaxIterations.Location = new Point(10, 90);
            lblMaxIterations.Name = "lblMaxIterations";
            lblMaxIterations.Size = new Size(90, 15);
            lblMaxIterations.TabIndex = 4;
            lblMaxIterations.Text = "İterasyon Sayısı:";
            // 
            // numDimension
            // 
            numDimension.Location = new Point(155, 58);
            numDimension.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numDimension.Name = "numDimension";
            numDimension.Size = new Size(100, 23);
            numDimension.TabIndex = 3;
            numDimension.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // lblDimension
            // 
            lblDimension.AutoSize = true;
            lblDimension.Location = new Point(10, 60);
            lblDimension.Name = "lblDimension";
            lblDimension.Size = new Size(95, 15);
            lblDimension.TabIndex = 2;
            lblDimension.Text = "Parçacık Boyutu:";
            // 
            // numParticleCount
            // 
            numParticleCount.Location = new Point(155, 28);
            numParticleCount.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numParticleCount.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            numParticleCount.Name = "numParticleCount";
            numParticleCount.Size = new Size(100, 23);
            numParticleCount.TabIndex = 1;
            numParticleCount.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // lblParticleCount
            // 
            lblParticleCount.AutoSize = true;
            lblParticleCount.Location = new Point(10, 30);
            lblParticleCount.Name = "lblParticleCount";
            lblParticleCount.Size = new Size(86, 15);
            lblParticleCount.TabIndex = 0;
            lblParticleCount.Text = "Parçacık Sayısı:";
            // 
            // btnStart
            // 
            btnStart.Location = new Point(81, 309);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(143, 33);
            btnStart.TabIndex = 1;
            btnStart.Text = "Optimizasyonu Başlat";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // txtResult
            // 
            txtResult.Location = new Point(307, 341);
            txtResult.Multiline = true;
            txtResult.Name = "txtResult";
            txtResult.ReadOnly = true;
            txtResult.Size = new Size(481, 97);
            txtResult.TabIndex = 3;
            // 
            // lblResults
            // 
            lblResults.AutoSize = true;
            lblResults.Location = new Point(307, 323);
            lblResults.Name = "lblResults";
            lblResults.Size = new Size(56, 15);
            lblResults.TabIndex = 4;
            lblResults.Text = "Sonuçlar:";
            // 
            // lblChart
            // 
            lblChart.AutoSize = true;
            lblChart.Location = new Point(307, 22);
            lblChart.Name = "lblChart";
            lblChart.Size = new Size(104, 15);
            lblChart.TabIndex = 5;
            lblChart.Text = "Yakınsama Grafiği:";
            // 
            // chartConvergence
            // 
            chartConvergence.BorderlineColor = Color.Black;
            chartConvergence.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartConvergence.BorderlineWidth = 1;
            chartConvergence.Location = new Point(307, 40);
            chartConvergence.Name = "chartConvergence";
            chartConvergence.Size = new Size(481, 262);
            chartConvergence.TabIndex = 2;
            chartConvergence.Text = "Yakınsama Grafiği";
            // 
            // panelRight
            // 
            panelRight.Controls.Add(lblAlgorithmDescription);
            panelRight.Controls.Add(txtAlgorithmDescription);
            panelRight.Dock = DockStyle.Fill;
            panelRight.Location = new Point(0, 0);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(300, 600);
            panelRight.TabIndex = 0;
            // 
            // lblAlgorithmDescription
            // 
            lblAlgorithmDescription.AutoSize = true;
            lblAlgorithmDescription.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAlgorithmDescription.Location = new Point(10, 10);
            lblAlgorithmDescription.Name = "lblAlgorithmDescription";
            lblAlgorithmDescription.Size = new Size(177, 15);
            lblAlgorithmDescription.TabIndex = 0;
            lblAlgorithmDescription.Text = "PSO ALGORİTMASI AÇIKLAMA";
            // 
            // txtAlgorithmDescription
            // 
            txtAlgorithmDescription.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtAlgorithmDescription.Font = new Font("Consolas", 9F);
            txtAlgorithmDescription.Location = new Point(10, 30);
            txtAlgorithmDescription.Name = "txtAlgorithmDescription";
            txtAlgorithmDescription.ReadOnly = true;
            txtAlgorithmDescription.Size = new Size(280, 560);
            txtAlgorithmDescription.TabIndex = 0;
            txtAlgorithmDescription.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 600);
            Controls.Add(splitContainerMain);
            Name = "Form1";
            Text = "Parçacık Sürü Optimizasyonu";
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            groupBoxParameters.ResumeLayout(false);
            groupBoxParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numMaxX).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMinX).EndInit();
            ((System.ComponentModel.ISupportInitialize)numVMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)numC2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numC1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMaxIterations).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDimension).EndInit();
            ((System.ComponentModel.ISupportInitialize)numParticleCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartConvergence).EndInit();
            panelRight.ResumeLayout(false);
            panelRight.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.GroupBox groupBoxParameters;
        private System.Windows.Forms.NumericUpDown numMaxX;
        private System.Windows.Forms.Label lblMaxX;
        private System.Windows.Forms.NumericUpDown numMinX;
        private System.Windows.Forms.Label lblMinX;
        private System.Windows.Forms.NumericUpDown numVMax;
        private System.Windows.Forms.Label lblVMax;
        private System.Windows.Forms.NumericUpDown numC2;
        private System.Windows.Forms.Label lblC2;
        private System.Windows.Forms.NumericUpDown numC1;
        private System.Windows.Forms.Label lblC1;
        private System.Windows.Forms.NumericUpDown numMaxIterations;
        private System.Windows.Forms.Label lblMaxIterations;
        private System.Windows.Forms.NumericUpDown numDimension;
        private System.Windows.Forms.Label lblDimension;
        private System.Windows.Forms.NumericUpDown numParticleCount;
        private System.Windows.Forms.Label lblParticleCount;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartConvergence;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.Label lblChart;
        private System.Windows.Forms.Label lblAlgorithmDescription;
        private System.Windows.Forms.RichTextBox txtAlgorithmDescription;
    }
}
