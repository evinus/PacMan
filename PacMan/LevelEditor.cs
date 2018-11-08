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

namespace PacMan
{
    public partial class LevelEditor : Form
    {
        public Map Map { get; private set; }


        public LevelEditor()
        {
            InitializeComponent();
            this.dgvTiles.AllowUserToAddRows = true;

            Column1.Items.AddRange(Enum.GetNames(typeof(enumTile)));
            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAddColumn_Click(object sender, EventArgs e)
        {
            DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
            column.Items.AddRange(Enum.GetNames(typeof(enumTile)));
            
            dgvTiles.Columns.Add(column);
        }
        private void Save()
        {
            if(MessageBox.Show("Har du fyllt alla rutor förutom den sista raden? alla måste vara fyllda","Allt klart?",MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }

            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int width = dgvTiles.ColumnCount;
                int height = dgvTiles.RowCount -1;

                using (FileStream filestream = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    BinaryWriter writer = new BinaryWriter(filestream);
                    
                    writer.Write(width);
                    writer.Write(height);
                    string type;
                    enumTile enumType;
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            type = (string)dgvTiles.Rows[y].Cells[x].FormattedValue;
                            if(Enum.TryParse(type,out enumType) == false)
                            {
                                MessageBox.Show("Något gick fel när du försökte spara.");
                                writer.Dispose();
                                return;
                            }
                            writer.Write((int)enumType);
                        }
                    }

                    writer.Dispose();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (FileStream filestream = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read))
                {
                    BinaryReader reader = new BinaryReader(filestream);

                    int width = reader.ReadInt32();
                    int height = reader.ReadInt32();
                    dgvTiles.Rows.Clear();
                    dgvTiles.Columns.Clear();
                    
                    
                    for (int i = 0; i < width; i++)
                    {
                        dgvTiles.Columns.Add((DataGridViewComboBoxColumn)Column1.Clone());
                    }
                    dgvTiles.Rows.Add(height);
                    for ( int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            enumTile enumTile = (enumTile)reader.ReadInt32();
                            dgvTiles.Rows[y].Cells[x].Value = enumTile.ToString();
                        }
                    }
                    reader.Dispose();
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            dgvTiles.Columns.RemoveAt(dgvTiles.Columns.Count - 1);
        }
    }
}
