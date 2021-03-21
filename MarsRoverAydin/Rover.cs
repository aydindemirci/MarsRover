using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverAydin
{
    class Rover
    {
        public Coordinate _coordinate { get; set; }
        public Directions _direction { get; set; }
        private Plateau _plateau { get; set; }

        public Rover(Coordinate coordinate,Directions directions)
        {
            _coordinate = coordinate;
            _direction = directions;
        }

        public string Go(Plateau plateau,String RoverControl)
        {
            _plateau = plateau;
            var _roverControl = RoverControl.ToCharArray();

            try
            {
                for (int i = 0; i < _roverControl.Length; i++)
                {
                    if (_roverControl[i] == 'M')
                        Move();
                    else
                        Spin(_roverControl[i]);
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }

            return string.Empty;
        }


        private void Move()
        {
            switch (_direction)
            {
                case Directions.N: 
                    _coordinate.Y++;
                    break;
                case Directions.S:
                    _coordinate.Y--;
                    break;
                case Directions.W:
                    _coordinate.X--;
                    break;
                case Directions.E:
                    _coordinate.X++;
                    break;
            }

            if (_coordinate.X < 0 || 
                _coordinate.Y < 0 || 
                _coordinate.X >_plateau._coordinate.X || 
                _coordinate.Y > _plateau._coordinate.Y)
            {
                throw new Exception("The Rover Off The Plateau!...");
            }
        }

        private void Spin(char spinDirection)
        {
            int tempDirection = (int)_direction;
            if (spinDirection== 'L')
                tempDirection--;
            else
                tempDirection++;

            if (tempDirection == -1)
                tempDirection = 3;

            if (tempDirection == 4)
                tempDirection = 0;

            _direction = (Directions)tempDirection;
        }
    }
}
