using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L1B
{
    public class SecretNumber
    {
        private int[] _guessedNumbers;
        private int _number;
        public const int MaxNumberOfGuesses = 7;
        private bool _canMakeGuess;
        private int _count;

        public SecretNumber()
        {
            _guessedNumbers = new int[MaxNumberOfGuesses];
            Initialize();
        }
        public bool CanMakeGuess {
            get
            {
                foreach (int guessedNumber in _guessedNumbers)
                {
                    if (_number == guessedNumber)
                        return false;
                
                }
                if (Count >= MaxNumberOfGuesses || _canMakeGuess == false)
                    return false;
              
                return true;
            }
            private set { _canMakeGuess = value; }
        }
      
        public int Count
        {
            get { return _count; }
            private set { _count = value; }
        }
        public int GuessesLeft {
            get { return MaxNumberOfGuesses - Count; }
        }


        public void Initialize()
        {
            Random randomNumber = new Random();
            _number = randomNumber.Next(1, 101);
            Count = 0;
            CanMakeGuess = true;
            Array.Clear(_guessedNumbers, 0, _guessedNumbers.Length);
        }

        public bool MakeGuess(int number)
        {


            if (Count >= MaxNumberOfGuesses)
                throw new ApplicationException();
            else if (number < 1 || number > 100)
                throw new ArgumentOutOfRangeException();

            foreach (int guessedNumber in _guessedNumbers)
            {
                if (number == guessedNumber)
                {
                   
                    Console.WriteLine("Du har redan gissat på {0}. Gör om din gissning!", number);
                    return false;
                }
            }

            _guessedNumbers[Count] = number;
            Count++;

            if (number > _number)
                Console.Write("{0} är för högt.", number);
            else if (number < _number)
                Console.Write("{0} är för lågt.", number);
            else
            {
                Console.WriteLine("RÄTT GISSAT! Grattis du klarade det på {0} försöket.", Count);
                return true;
            }

            Console.WriteLine("Du har {0} gissningar kvar.", GuessesLeft);

            if(GuessesLeft==0)
                Console.WriteLine("Det hemliga talet är {0}.", _number);

            return false;
        }
    }
}
