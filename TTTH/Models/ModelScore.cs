using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTH.Models
{
    public class ModelScore
    {
        private int examNumber = -1;

        private DTOCLass modelClass = new DTOCLass();
        private ModelStudent modelStudent = new ModelStudent();
        private double score = 0;

        public ModelScore() { } 
        public ModelScore(int examNumber, DTOCLass modelClass, ModelStudent modelStudent, double score)
        {
            this.ExamNumber = examNumber;

            this.ModelClass = modelClass;
            this.ModelStudent = modelStudent;
            this.Score = score;
        }

        public int ExamNumber { get => examNumber; set => examNumber = value; }
        public DTOCLass ModelClass { get => modelClass; set => modelClass = value; }
        public ModelStudent ModelStudent { get => modelStudent; set => modelStudent = value; }
        public string StudentName { get => modelStudent.Name; }
        public string StudentPhoneNumber { get => modelStudent.Name; }
        public double Score { get => score; set => score = value; }
    }
}
