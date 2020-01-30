using System;
namespace ShowImageFromJason
{
    class ImgModel : IEquatable<ImgModel>, IComparable<ImgModel>
    {
        public string Answer { set; get; }
        public bool Forced { set; get; }
        public string Image { set; get; }
        public ImgModel() { }
        public ImgModel(string answer, string image) {
            Answer = answer;
            Image = image;
        }
        public override string ToString()
        {
            return Answer + " " + Image;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            ImgModel objAsImgModel = obj as ImgModel;
            if (objAsImgModel == null) return false;
            else return Equals(objAsImgModel);
        }
        public int SortByNameAscending(string answer1, string answer2)
        {
           return answer1.CompareTo(answer2);
        }

        public int CompareTo(ImgModel compareImgModel)
        {
            if (compareImgModel == null)
                return 1;
            else
                return this.Answer.CompareTo(compareImgModel.Answer);
        }       
        public bool Equals(ImgModel other)
        {
            if (other == null) return false;
            return (this.Answer.Equals(other.Answer));
        }
    }
}
