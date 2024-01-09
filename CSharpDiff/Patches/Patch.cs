using System.Text.RegularExpressions;
            var oldFileName = (String.IsNullOrEmpty(diff.OldFileName) ? "/dev/null" : diff.OldFileName);
            var newFileName = (String.IsNullOrEmpty(diff.NewFileName) ? "/dev/null" : diff.NewFileName);

            ret.Add($"diff --git {oldFileName} {newFileName}");

            else if (diff.OldFileName is null && diff.NewFileName is not null)
            {
                ret.Add("new file mode 100644");
            }
            else if (diff.NewFileName is null && diff.OldFileName is not null)
            {
                ret.Add("deleted file mode 100644");
            }


            ret.Add("--- " + oldFileName + (String.IsNullOrEmpty(diff.OldHeader) ? "" : '\t' + diff.OldHeader));
            ret.Add("+++ " + newFileName + (String.IsNullOrEmpty(diff.NewHeader) ? "" : '\t' + diff.NewHeader));

