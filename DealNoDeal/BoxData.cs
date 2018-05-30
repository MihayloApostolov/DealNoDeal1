using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealNoDeal
{
    static public class BoxData
    {
        static private List<Box> _CurentBoxes = new List<Box>();
        static private List<Box> _CurentBoxesR = new List<Box>();

        static public List<Box> CurentBoxes
        {
            get
            {
                _CurentBoxes.Clear();
                FillBoxesInOrder();
                return _CurentBoxes;
            }
            private set { }
        }

        static public List<Box> CurentBoxesR
        {
            get
            {
                _CurentBoxesR.Clear();
                FillBoxesRandomly();
                return _CurentBoxesR;
            }
            private set { }
        }

       


        static private void FillBoxesInOrder()
        {
            string[] BoxValues = new string[22] { "0.10","0.20","0.50","1","Предмет","10","20","50","100","200",
                   "300", "750","1,000","2,500","5,000","7,500","10,000","12,500","15,000","25,000","50,000","100,000"};

            int loop = 1;
            for (int i = 0; i < BoxValues.Length; i++)
            {
                _CurentBoxes.Add(new Box()
                {
                    boxNumber = loop,
                    boxValue = BoxValues[i]
                }

               );
                loop++;
            }

            
            }
        static private void FillBoxesRandomly()
        {
            FillBoxesInOrder();

            int newBoxIndex = 1;
            var rnd = new Random(DateTime.Now.Millisecond);

            while (_CurentBoxes.Count != 0)
            {
                
                int index = rnd.Next(0, _CurentBoxes.Count);
                _CurentBoxesR.Add(new Box()
                {
                    boxNumber = newBoxIndex,
                    boxValue = _CurentBoxes[index].boxValue
                }
                    );
                _CurentBoxes.Remove(_CurentBoxes[index]);
                newBoxIndex++;
            }
        }

    }
}
