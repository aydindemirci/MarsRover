using System;

namespace MarsRoverAydin
{
    class Program
    {

        static Plateau plateau;
        static Rover rover;

        static void Main(string[] args)
        {
            Continue();
        }

        static void Continue()
        {
            CreatePlateau();

            while (1 == 1)
            {
                Console.WriteLine("Write \"Plateau\" To Change Plateau");
                CreateRover();

                Console.WriteLine("Write \"Plateau\" To Change Plateau");
                RoverGo();

                Console.WriteLine(rover._coordinate.X.ToString() + " " + rover._coordinate.Y.ToString() + " " + rover._direction);
            }
           
        }

        static void CreatePlateau()
        {
            Console.WriteLine("Enter Plateau Coordinates(x y) (There must be a gap in between) : ");
            string _plateauCoordinate = Console.ReadLine();
            var plateauCoordinate = _plateauCoordinate.Split(" ");

            if (plateauCoordinate.Length != 2)
            {
                Console.WriteLine("Error Plateau Coordinates!!!!");
                CreatePlateau();
            }

            Coordinate coordinate = new Coordinate();
            try
            {
                coordinate.X = int.Parse(plateauCoordinate[0]);
                coordinate.Y = int.Parse(plateauCoordinate[1]);
            }
            catch
            {
                Console.WriteLine("Error Plateau Coordinates!!!!");
                CreatePlateau();
            }

            plateau = new Plateau(coordinate);
        }

        static void CreateRover()
        {
            Console.WriteLine("Enter Rover Coordinates and Direction (x y N) : ");
            string _roverDetail = Console.ReadLine();
            var roverDetail = _roverDetail.Split(" ");

            if (_roverDetail.ToUpper() == "PLATEAU")
                Continue();

            if (roverDetail.Length != 3)
            {
                Console.WriteLine("Error Rover Details!!!!");
                CreateRover();
            }

            Coordinate coordinate = new Coordinate();
            try
            {
                coordinate.X = int.Parse(roverDetail[0]);
                coordinate.Y = int.Parse(roverDetail[1]);
            }
            catch
            {
                Console.WriteLine("Error Rover Coordinates!!!!");
                CreateRover();
            }

            Directions roverDirection = Directions.N;
            try
            {
              roverDirection = Enum.Parse<Directions>(roverDetail[2].ToUpper());
            }
            catch
            {
                Console.WriteLine("Error Rover Direction!.. Undefined Direction");
                CreateRover();
            }

            rover = new Rover(coordinate, roverDirection);
        }

        static void RoverGo()
        {
            Console.WriteLine("Enter Simple String For Rover Control(LMLMLMLMM) : ");
            string _roverControl = Console.ReadLine().ToUpper();

            if (_roverControl.ToUpper() == "PLATEAU")
                Continue();

            isValidControl(_roverControl);

            string result =  rover.Go(plateau, _roverControl);
            if (result != string.Empty)
            {
                Console.WriteLine(result);
                RoverGo();
            }
        }

        static void isValidControl( string roverControl)
        {
            var _roverControl = roverControl.ToCharArray();

            for (int i = 0; i < _roverControl.Length; i++)
            {
                if (_roverControl[i] != 'L' && _roverControl[i] != 'R' && _roverControl[i] != 'M')
                {
                    Console.WriteLine("Error Rover Control!.. Enter L or R or M");
                    RoverGo();
                }
            }
        }
    }

}
