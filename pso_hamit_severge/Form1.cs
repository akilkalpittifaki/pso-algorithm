using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace pso_hamit_severge
{
    public partial class Form1 : Form
    {
        private PSO? pso;
        private bool isRunning = false;
        private List<double> currentConvergence = new List<double>();

        public Form1()
        {
            // Initialize all components
            InitializeComponent();
            
            // Add form load event handler
            this.Load += Form1_Load;
            
            try
            {
                // Uygulama başlangıcında chart'ı yapılandırma
                SetupChart();
                
                // Set default values in the UI
                SetDefaultValues();
                
                // Load algorithm description into the txtAlgorithmDescription
                LoadAlgorithmDescription();
                
                // Hamit Severge imzası - Form başlığına ekle (sürekli görünür olacak)
                this.Text = "Parçacık Sürü Optimizasyonu - Hamit Severge";
                
                // Görünür bir Geliştirici etiketi ekle
                AddDeveloperLabel();
                
                // Gizli bir alan ekle, hoca için doğrulama aracı
                AddVerificationCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in constructor: {ex.Message}");
                MessageBox.Show($"Form başlatılırken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // Make sure the split container's splitter distance is set correctly
                splitContainerMain.SplitterDistance = 350;
                
                // Make sure all elements are visible
                this.Refresh();
                
                Console.WriteLine("Form loaded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Form_Load: {ex.Message}");
                MessageBox.Show($"Form yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAlgorithmDescription()
        {
            try
            {
                string algorithmFilePath = Path.Combine(Application.StartupPath, "ps_algoritma.txt");
                
                if (File.Exists(algorithmFilePath))
                {
                    string content = File.ReadAllText(algorithmFilePath);
                    txtAlgorithmDescription.Text = content;
                }
                else
                {
                    // Dosya bulunamazsa, en azından mevcut algoritma bilgilerini göster
                    txtAlgorithmDescription.Text = 
                        "PARÇACIK SÜRÜ OPTİMİZASYONU (PSO) ALGORİTMA AÇIKLAMASI\n\n" +
                        "PSO algoritması, kuş ve balık sürülerinin sosyal davranışlarından esinlenerek geliştirilmiş, " +
                        "popülasyon temelli bir optimizasyon tekniğidir.\n\n" +
                        "İki temel formül kullanır:\n" +
                        "1. Hız güncelleme: v_i^(k+1) = v_i^k + c1*r1*(pbest_i^k - x_i^k) + c2*r2*(gbest^k - x_i^k)\n" +
                        "2. Konum güncelleme: x_i^(k+1) = x_i^k + v_i^(k+1)\n\n" +
                        "Detaylı bilgiler için kaynak kod içindeki açıklamalara bakınız.";
                }
            }
            catch (Exception ex)
            {
                // Dosya okunurken hata oluşursa sessizce geç
                txtAlgorithmDescription.Text = "Algoritma açıklaması yüklenirken hata oluştu: " + ex.Message;
            }
        }

        private void btnAlgorithmInfo_Click(object sender, EventArgs e)
        {
            // Algoritma açıklamasını göstermek için yeni bir form oluştur
            Form algorithmForm = new Form();
            algorithmForm.Text = "PSO Algoritma Açıklaması";
            algorithmForm.Size = new Size(800, 600);
            algorithmForm.StartPosition = FormStartPosition.CenterScreen;
            
            // RichTextBox ekle
            RichTextBox txtAlgorithmDescription = new RichTextBox();
            txtAlgorithmDescription.Dock = DockStyle.Fill;
            txtAlgorithmDescription.ReadOnly = true;
            txtAlgorithmDescription.Font = new Font("Consolas", 9F, FontStyle.Regular);
            
            // Açıklama metnini yükle
            try
            {
                string algorithmFilePath = Path.Combine(Application.StartupPath, "ps_algoritma.txt");
                
                if (File.Exists(algorithmFilePath))
                {
                    string content = File.ReadAllText(algorithmFilePath);
                    txtAlgorithmDescription.Text = content;
                }
                else
                {
                    // Dosya bulunamazsa, en azından mevcut algoritma bilgilerini göster
                    txtAlgorithmDescription.Text = 
                        "PARÇACIK SÜRÜ OPTİMİZASYONU (PSO) ALGORİTMA AÇIKLAMASI\n\n" +
                        "PSO algoritması, kuş ve balık sürülerinin sosyal davranışlarından esinlenerek geliştirilmiş, " +
                        "popülasyon temelli bir optimizasyon tekniğidir.\n\n" +
                        "İki temel formül kullanır:\n" +
                        "1. Hız güncelleme: v_i^(k+1) = v_i^k + c1*r1*(pbest_i^k - x_i^k) + c2*r2*(gbest^k - x_i^k)\n" +
                        "2. Konum güncelleme: x_i^(k+1) = x_i^k + v_i^(k+1)\n\n" +
                        "Detaylı bilgiler için kaynak kod içindeki açıklamalara bakınız.";
                }
            }
            catch (Exception ex)
            {
                // Dosya okunurken hata oluşursa sessizce geç
                txtAlgorithmDescription.Text = "Algoritma açıklaması yüklenirken hata oluştu: " + ex.Message;
            }
            
            // Form'a RichTextBox ekle
            algorithmForm.Controls.Add(txtAlgorithmDescription);
            
            // Form'u göster
            algorithmForm.Show();
        }
        
        private void SetupChart()
        {
            try
            {
                if (chartConvergence == null)
                {
                    chartConvergence = new System.Windows.Forms.DataVisualization.Charting.Chart();
                    chartConvergence.Location = new Point(307, 40);
                    chartConvergence.Name = "chartConvergence";
                    chartConvergence.Size = new Size(481, 262);
                    chartConvergence.Text = "Yakınsama Grafiği";
                    chartConvergence.BorderlineColor = Color.Black;
                    chartConvergence.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
                    chartConvergence.BorderlineWidth = 1;
                    panelLeft.Controls.Add(chartConvergence);
                }
                
                // Completely clear and recreate chart elements
                chartConvergence.Series.Clear();
                chartConvergence.ChartAreas.Clear();
                chartConvergence.Legends.Clear();
                
                // Add chart area
                System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea("MainArea");
                chartArea.AxisX.Title = "Iterasyon Sayısı";
                chartArea.AxisY.Title = "En İyi Amaç Fonksiyon Değeri";
                chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
                chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
                chartArea.BackColor = Color.White;
                chartArea.AxisX.Minimum = 0;
                chartConvergence.ChartAreas.Add(chartArea);
                
                // Add legend
                System.Windows.Forms.DataVisualization.Charting.Legend legend = new System.Windows.Forms.DataVisualization.Charting.Legend("MainLegend");
                legend.Enabled = false;
                chartConvergence.Legends.Add(legend);
                
                // Add series
                System.Windows.Forms.DataVisualization.Charting.Series series = new System.Windows.Forms.DataVisualization.Charting.Series("Convergence");
                series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                series.Color = Color.Red;
                series.BorderWidth = 2;
                series.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
                series.MarkerSize = 5;
                series.ChartArea = "MainArea";
                series.Legend = "MainLegend";
                chartConvergence.Series.Add(series);
                
                // Make sure chart is visible
                chartConvergence.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Grafik oluşturulurken hata oluştu: {ex.Message}", "Grafik Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetDefaultValues()
        {
            numParticleCount.Value = 10;
            numDimension.Value = 2;
            numMaxIterations.Value = 200;
            numC1.Value = 2.0m;
            numC2.Value = 2.0m;
            numVMax.Value = 1.0m;
            numMinX.Value = -5.0m;
            numMaxX.Value = 5.0m;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                MessageBox.Show("Optimizasyon zaten çalışıyor!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                isRunning = true;
                btnStart.Enabled = false;
                
                // Reset chart and results
                SetupChart();
                txtResult.Clear();
                currentConvergence.Clear();
                
                // Get parameters from UI
                int particleCount = (int)numParticleCount.Value;
                int dimension = (int)numDimension.Value;
                int maxIterations = (int)numMaxIterations.Value;
                double c1 = (double)numC1.Value;
                double c2 = (double)numC2.Value;
                double vMax = (double)numVMax.Value;
                double minX = (double)numMinX.Value;
                double maxX = (double)numMaxX.Value;

                // Create arrays for bounds
                double[] lowerBounds = new double[dimension];
                double[] upperBounds = new double[dimension];
                
                for (int i = 0; i < dimension; i++)
                {
                    lowerBounds[i] = minX;
                    upperBounds[i] = maxX;
                }

                // Create PSO instance
                pso = new PSO(
                    particleCount,
                    dimension,
                    maxIterations,
                    c1,
                    c2,
                    vMax,
                    lowerBounds,
                    upperBounds,
                    TestFunctions.SixHumpCamelBack
                );
                
                // Subscribe to iteration completed event for real-time updates
                pso.IterationCompleted += OnIterationCompleted;

                // Run optimization in a separate task to avoid UI freezing
                Task.Run(() => RunOptimization());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isRunning = false;
                btnStart.Enabled = true;
            }
        }
        
        private void OnIterationCompleted(int iteration, double bestFitness)
        {
            // Update UI with current best fitness (real-time updates)
            try
            {
                lock (currentConvergence)
                {
                    currentConvergence.Add(bestFitness);
                }
                
                // Only update UI occasionally to avoid freezing
                if (iteration % 5 == 0 || iteration == 0)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        List<double> snapshot;
                        lock (currentConvergence)
                        {
                            snapshot = new List<double>(currentConvergence);
                        }
                        
                        ChartHelper.PlotConvergence(chartConvergence, snapshot);
                        
                        // İsmi sürekli göster, değiştirme
                        this.Text = $"Parçacık Sürü Optimizasyonu - Hamit Severge - İterasyon: {iteration+1}";
                    });
                }
            }
            catch
            {
                // Ignore UI update errors during progress
            }
        }

        private void RunOptimization()
        {
            try
            {
                if (pso == null) return;
                
                // Run the optimization
                var (solution, fitness) = pso.Optimize();

                // Update UI after optimization is done
                this.Invoke((MethodInvoker)delegate
                {
                    try
                    {
                        // Plot final convergence
                        if (pso != null)
                        {
                            ChartHelper.PlotConvergence(chartConvergence, pso.ConvergenceHistory);
                        
                            // Display results with Hamit Severge imzası - daha belirgin
                            txtResult.Text = $"HAMIT SEVERGE - OPTİMİZASYON SONUÇLARI\r\n";
                            txtResult.Text += $"========================================\r\n";
                            txtResult.Text += $"En iyi amaç fonksiyon değeri: {fitness}\r\n\r\n";
                            
                            for (int i = 0; i < solution.Length; i++)
                            {
                                txtResult.Text += $"x{i + 1} = {solution[i]}\r\n";
                            }
                            
                            // Restore form title
                            this.Text = "Parçacık Sürü Optimizasyonu - Hamit Severge";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Grafik güncellenirken hata oluştu: {ex.Message}", "Grafik Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                    isRunning = false;
                    btnStart.Enabled = true;
                    
                    // Unsubscribe from event
                    if (pso != null)
                    {
                        pso.IterationCompleted -= OnIterationCompleted;
                    }
                });
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show($"Optimizasyon sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isRunning = false;
                    btnStart.Enabled = true;
                    
                    // Unsubscribe from event
                    if (pso != null)
                    {
                        pso.IterationCompleted -= OnIterationCompleted;
                    }
                });
            }
        }

        private void AddVerificationCode()
        {
            // Kontrol+Alt+H tuş kombinasyonu ekle
            this.KeyPreview = true;
            this.KeyDown += (s, e) =>
            {
                if (e.Control && e.Alt && e.KeyCode == Keys.H)
                {
                    MessageBox.Show(
                        "Bu uygulama Hamit Severge tarafından geliştirilmiştir.\n\n" +
                        "Öğrenci No: 123456789\n" +
                        "Teslim Tarihi: " + DateTime.Now.ToString("dd.MM.yyyy") + "\n\n" +
                        "Doğrulama Kodu: " + GenerateVerificationCode(),
                        "Geliştirici Doğrulaması",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            };
        }
        
        private string GenerateVerificationCode()
        {
            // Hamit Severge isminden ve bugünün tarihinden türetilen benzersiz kod
            string name = "HAMIT SEVERGE";
            DateTime today = DateTime.Today;
            
            // İsmin ASCII değerlerinin toplamı
            int nameSum = 0;
            foreach (char c in name)
            {
                nameSum += (int)c;
            }
            
            // Tarih değerleri
            int dateValue = today.Day + today.Month * 31 + (today.Year % 100) * 372;
            
            // Benzersiz kod oluştur
            int code = (nameSum * 17 + dateValue) % 10000;
            
            return code.ToString("D4");
        }

        private void AddDeveloperLabel()
        {
            // Görünür bir developer etiketi ekle
            Label lblDeveloper = new Label();
            lblDeveloper.Text = "Geliştirici: Hamit Severge";
            lblDeveloper.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold);
            lblDeveloper.ForeColor = Color.DarkBlue;
            lblDeveloper.AutoSize = true;
            lblDeveloper.Location = new Point(12, 350);
            panelLeft.Controls.Add(lblDeveloper);
        }
    }
}
