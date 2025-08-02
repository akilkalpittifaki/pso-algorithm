using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace pso_hamit_severge
{
    public static class ChartHelper
    {
        public static void InitializeConvergenceChart(Chart chart)
        {
            try
            {
                if (chart == null)
                    return;
                    
                chart.Series.Clear();
                
                // Add a series for the convergence data
                Series series = new Series("Convergence");
                series.ChartType = SeriesChartType.Line;
                series.Color = Color.Red;
                series.BorderWidth = 2;
                series.MarkerStyle = MarkerStyle.Circle;
                series.MarkerSize = 5;
                chart.Series.Add(series);
                
                // Configure chart areas
                if (chart.ChartAreas.Count == 0)
                    chart.ChartAreas.Add(new ChartArea());
                    
                chart.ChartAreas[0].AxisX.Title = "Iterasyon Sayısı";
                chart.ChartAreas[0].AxisY.Title = "En İyi Amaç Fonksiyon Değeri";
                chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
                chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
                chart.ChartAreas[0].BackColor = Color.White;
                chart.ChartAreas[0].AxisX.Minimum = 0;
                
                if (chart.Legends.Count == 0)
                    chart.Legends.Add(new Legend());
                    
                chart.Legends[0].Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Grafik yapılandırılırken hata oluştu: {ex.Message}", "Grafik Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        public static void PlotConvergence(Chart chart, List<double> convergenceHistory)
        {
            try
            {
                if (chart == null || chart.Series.Count == 0 || convergenceHistory == null || convergenceHistory.Count == 0)
                    return;
                    
                string seriesName = chart.Series.Count > 0 ? chart.Series[0].Name : "Convergence";
                
                if (!SeriesExists(chart, seriesName))
                {
                    Series series = new Series(seriesName);
                    series.ChartType = SeriesChartType.Line;
                    series.Color = Color.Red;
                    series.BorderWidth = 2;
                    series.MarkerStyle = MarkerStyle.Circle;
                    series.MarkerSize = 5;
                    chart.Series.Add(series);
                }
                
                chart.Series[seriesName].Points.Clear();
                
                double minY = double.MaxValue;
                double maxY = double.MinValue;
                
                // Hamit Severge adını ASCII kodlar halinde saklayacağız
                string name = "HAMIT SEVERGE";
                int nameIndex = 0;
                
                for (int i = 0; i < convergenceHistory.Count; i++)
                {
                    chart.Series[seriesName].Points.AddXY(i, convergenceHistory[i]);
                    
                    // Her noktanın renklerine veri gömme (steganografi)
                    if (i % 3 == 0 && nameIndex < name.Length)
                    {
                        // ASCII değerini kullanarak özel bir renk oluştur
                        int asciiCode = (int)name[nameIndex];
                        // R değeri normal, G değeri ASCII'den etkilenmiş, B değeri normal
                        Color hiddenColor = Color.FromArgb(255, 255, asciiCode % 200 + 30, 255);
                        chart.Series[seriesName].Points[i].MarkerColor = hiddenColor;
                        
                        nameIndex++;
                    }
                    
                    if (convergenceHistory[i] < minY)
                        minY = convergenceHistory[i];
                        
                    if (convergenceHistory[i] > maxY)
                        maxY = convergenceHistory[i];
                }
                
                // Eğer tüm isim kodlanamadıysa grafiğin belirli alanlarına ismin ilk harflerini kodla
                if (nameIndex < name.Length)
                {
                    // Grafiğin köşelerinde görünmez piksel ile isim kodlama (ileri seviye steganografi)
                    if (chart.ChartAreas.Count > 0)
                    {
                        chart.ChartAreas[0].BackSecondaryColor = Color.FromArgb(
                            255, 
                            (int)'H', // Hamit'in ilk harfi
                            (int)'S', // Severge'nin ilk harfi
                            255);
                        chart.ChartAreas[0].BackGradientStyle = GradientStyle.DiagonalRight;
                    }
                }
                
                // Add a margin to the axis range
                double margin = (maxY - minY) * 0.1;
                if (margin == 0) margin = Math.Abs(minY) * 0.1;
                if (margin == 0) margin = 1.0;
                
                if (chart.ChartAreas.Count == 0)
                    chart.ChartAreas.Add(new ChartArea());
                    
                chart.ChartAreas[0].AxisY.Minimum = minY - margin;
                chart.ChartAreas[0].AxisY.Maximum = maxY + margin;
                chart.ChartAreas[0].AxisX.Maximum = convergenceHistory.Count > 0 ? convergenceHistory.Count - 1 : 0;
                
                chart.ChartAreas[0].RecalculateAxesScale();
                chart.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Yakınsama grafiği çizilirken hata oluştu: {ex.Message}", "Grafik Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static bool SeriesExists(Chart chart, string seriesName)
        {
            foreach (Series series in chart.Series)
            {
                if (series.Name == seriesName)
                    return true;
            }
            return false;
        }
    }
} 