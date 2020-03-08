using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mertens3d.FabProChallenge.Shared.Models
{
    public class EffortResult
    {
        private bool Successful { get; set; } = false;
        private List<string> ErrorMessages { get; set; } = new List<string>();
        public int PayloadId { get; set; }

        public bool WasSuccessful()
        {
            return Successful && !ErrorMessages.Any();
        }

        public void MarkSuccessful()
        {
            Successful = true;
        }

        public void MarkFailed(string errorMessage)
        {
            ErrorMessages.Add(errorMessage);
            Successful = false;
        }

        public string ErrorMessagesBigString()
        {
            StringBuilder sb = new StringBuilder();
            ErrorMessages.ForEach(x => sb.Append(x + Environment.NewLine));

            return sb.ToString();
        }
    }
}