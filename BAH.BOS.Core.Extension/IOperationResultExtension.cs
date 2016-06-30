﻿using Kingdee.BOS.Core.DynamicForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kingdee.BOS.Core.DynamicForm
{
    public static class IOperationResultExtension
    {
        public static string GetErrorMessage(this IOperationResult result)
        {
            StringBuilder msg = new StringBuilder();
            result.ValidationErrors.ForEach(error =>
                msg.AppendLine(string.Format("主键：{0}，错误：{1}", error.BillPKID, error.Message)));
            result.GetFatalErrorResults().ForEach(error =>
                msg.AppendLine(string.Format("主键：{0}，错误：{1}", error.BillPKID, error.Message)));
            return msg.ToString();
        }//end method

        public static string GetErrorMessage(this IOperationResult result, string description)
        {
            StringBuilder msg = new StringBuilder();
            result.ValidationErrors.ForEach(error =>
                msg.AppendLine(string.Format("[{0}]主键：{1}，错误：{2}", description, error.BillPKID, error.Message)));
            result.GetFatalErrorResults().ForEach(error =>
                msg.AppendLine(string.Format("[{0}]主键：{1}，错误：{2}", description, error.BillPKID, error.Message)));
            return msg.ToString();
        }//end method

    }//end static class
}//end namespace