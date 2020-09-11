using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurtainDesigner.Classes
{
    public class ClassPatternPath
    {
        public static readonly string FC_PATTERN = Classes.PathCombiner.join_combine("\\report_patterns\\fc_pattern.docx");
        public static readonly string DNC_PATTERN = Classes.PathCombiner.join_combine("\\report_patterns\\dnc_pattern.docx");
        public static readonly string PC_PATTERN = Classes.PathCombiner.join_combine("\\report_patterns\\pc_pattern.docx");
        public static readonly string RC_PATTERN = Classes.PathCombiner.join_combine("\\report_patterns\\rc_pattern.docx");
        public static readonly string MC_PATTERN = Classes.PathCombiner.join_combine("\\report_patterns\\mc_pattern.docx");
        public static readonly string HC_PATTERN = Classes.PathCombiner.join_combine("\\report_patterns\\hc_pattern.docx");
    }
}
