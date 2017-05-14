using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeignKeyConstraints
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable tableBase = new DataTable("base");
            DataTable tableChild = new DataTable("chaild");

            DataColumn ColumnBase = tableBase.Columns.Add("base",typeof(int));
            DataColumn ColumnChild = tableChild.Columns.Add("child",typeof(int));
           // DataSet set = new DataSet();
            //set.Tables.AddRange(new DataTable[] { tableBase, tableChild });
            tableBase.Constraints.Add(new UniqueConstraint(ColumnBase));
            tableChild.Constraints.Add(new ForeignKeyConstraint(ColumnBase, ColumnChild));
            DataRow rowBAse = tableBase.NewRow();
            rowBAse[0] = 1;
            tableBase.Rows.Add(rowBAse);

            DataRow rowChild = tableChild.NewRow();
            rowChild[0] = 1;
            rowChild[0] = 0;
            tableChild.Rows.Add(rowChild);
        }
    }
}
