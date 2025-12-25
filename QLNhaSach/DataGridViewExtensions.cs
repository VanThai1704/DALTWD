using System;
using System.Windows.Forms;

namespace QLNhaSach
{
    public static class DataGridViewExtensions
    {
        public static void SetupVietnameseHeaders(this DataGridView dgv)
        {
            if (dgv == null) return;
            // Ensure header visual styles disabled so custom fonts/styles apply
            dgv.EnableHeadersVisualStyles = false;

            void ApplyHeaders(object? sender, DataGridViewBindingCompleteEventArgs e)
            {
                if (dgv != null && dgv.Columns != null && dgv.Columns.Count > 0)
                {
                    GridHelper.ApplyVietnameseColumnHeaders(dgv);
                    dgv.Invalidate();
                    dgv.Refresh();
                }
            }

            void OnColumnAdded(object? sender, DataGridViewColumnEventArgs e)
            {
                if (dgv != null && dgv.Columns != null && dgv.Columns.Count > 0)
                {
                    GridHelper.ApplyVietnameseColumnHeaders(dgv);
                }
            }

            void OnDataSourceChanged(object? sender, EventArgs e)
            {
                if (dgv != null && dgv.Columns != null && dgv.Columns.Count > 0)
                {
                    GridHelper.ApplyVietnameseColumnHeaders(dgv);
                }
            }

            // Attach events (avoid duplicate attaching)
            dgv.DataBindingComplete -= ApplyHeaders;
            dgv.DataBindingComplete += ApplyHeaders;

            dgv.DataSourceChanged -= OnDataSourceChanged;
            dgv.DataSourceChanged += OnDataSourceChanged;

            dgv.ColumnAdded -= OnColumnAdded;
            dgv.ColumnAdded += OnColumnAdded;

            // Also apply now if columns exist
            if (dgv.Columns != null && dgv.Columns.Count > 0)
            {
                GridHelper.ApplyVietnameseColumnHeaders(dgv);
            }
        }
    }
}
