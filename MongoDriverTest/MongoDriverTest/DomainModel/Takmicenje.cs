using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MongoDB.DomainModel
{
    class Takmicenje
    {
        public String Ime { get; set; }
        public String Opis { get; set; } /*Neki opis, sta god da je. Samo za sva da budu na istu foru*/
        public String SpisakDrzava { get; set; } /*Spisak reprezentacija koje ucestvuju na tom takmicenju, za FIFA su sve tako da tamo ne treba :)*/
        public String SistemIgranja { get; set; } /*na foru prvo se igraju 5 grupe sa po 4 tima, prva 2 u svakoj grupi prolaze, posle se igra na ispadanje,... Na to sam mislio;;*/
        public String PoslednjiPobednik { get; set; } /*Poslednja reprezentacija koja je osvojila*/
        public String Statistika { get; set; } /*3 drzave koje su najvise puta osvajale;; eventualno jos nesto;;*/
        //public Image Logo { get; set; } /*Logo takmicenja*/

        // ---- Sva takmicenja ----
        // 1. FIFA (Intercontinental competitions)
        // 2. AFC (Asian competitions)
        // 3. CAF (African competitions)
        // 4. CONCACAF (North American, Central American and Caribbean competitions)
        // 5. CONMEBOL (South American competitions)
        // 6. OFC (Oceanian competitions)
        // 7. UEFA (European competitions)
    }
}
