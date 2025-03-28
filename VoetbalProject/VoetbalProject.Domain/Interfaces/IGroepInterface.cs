using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoetbalProject.Domain.Models;

namespace VoetbalProject.Domain.Interfaces
{
    public interface IGroepInterface
    {
        Groep GetGroepById(long groepId);
        List<Groep> GetGroepen();
        int GetGroupSpelerCount(Groep groep);
    }
}
