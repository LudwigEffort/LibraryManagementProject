namespace LibraryManagementApp.Core
{
    public class Loan
    {
       
        private User user;
        private Document document;
        private int dataIn,dataFi;
        public int Alfanumerico;
        public Loan(User User,Document Document,int DataIn,int DataFi)
        {
            user=User;
            document=Document;
            dataIn=DataIn;
            dataFi=DataFi;
        }
        
    }
  
}