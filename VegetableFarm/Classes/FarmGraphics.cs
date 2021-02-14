using System.Drawing;

namespace VegetableFarm.Classes
{
    static class FarmGraphics
    {
        public static Image empty = Image.FromFile(@"C:\Users\Alyona\source\repos\VegetableFarm\VegetableFarm\Resources\start_growing.jpg");
        public static Image planted = Image.FromFile(@"C:\Users\Alyona\source\repos\VegetableFarm\VegetableFarm\Resources\текстура_почвы.jpg");
        public static Image green = Image.FromFile(@"C:\Users\Alyona\source\repos\VegetableFarm\VegetableFarm\Resources\текстура_побег_растения.jpg");
        public static Image immature = Image.FromFile(@"C:\Users\Alyona\source\repos\VegetableFarm\VegetableFarm\Resources\близко_созрелые.jpg");
        public static Image mature = Image.FromFile(@"C:\Users\Alyona\source\repos\VegetableFarm\VegetableFarm\Resources\зрелые.jpg");
        public static Image overgrow = Image.FromFile(@"C:\Users\Alyona\source\repos\VegetableFarm\VegetableFarm\Resources\гнилые.jpg");
    }
}
