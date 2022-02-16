using CommonLayer.Label;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface ILabelBL
    {
        Task CreateLabel(int noteId, int userId, LabelModal labelModal);
        
    }
}
