using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangoverHunt
{
    public class Host
    {
        private readonly Player _player;

        public Host(Riddle riddle)
        {
            _player = new Player(this);
            Riddle = riddle;
        }

        public Riddle Riddle { get; private set; }
    }
}
