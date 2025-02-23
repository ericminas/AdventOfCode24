using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode24.Days
{
    internal class Day5
    {
        public string InputStr = "84|39\r\n48|11\r\n48|79\r\n88|98\r\n88|82\r\n88|12\r\n69|67\r\n69|77\r\n69|22\r\n69|61\r\n41|75\r\n41|56\r\n41|59\r\n41|95\r\n41|83\r\n24|97\r\n24|98\r\n24|54\r\n24|48\r\n24|47\r\n24|16\r\n33|59\r\n33|92\r\n33|47\r\n33|16\r\n33|82\r\n33|88\r\n33|78\r\n92|82\r\n92|59\r\n92|88\r\n92|78\r\n92|97\r\n92|63\r\n92|56\r\n92|74\r\n11|35\r\n11|39\r\n11|27\r\n11|75\r\n11|47\r\n11|24\r\n11|77\r\n11|79\r\n11|43\r\n36|44\r\n36|33\r\n36|46\r\n36|26\r\n36|83\r\n36|35\r\n36|96\r\n36|39\r\n36|72\r\n36|76\r\n59|55\r\n59|78\r\n59|84\r\n59|36\r\n59|69\r\n59|61\r\n59|97\r\n59|17\r\n59|12\r\n59|67\r\n59|76\r\n98|55\r\n98|66\r\n98|32\r\n98|97\r\n98|61\r\n98|67\r\n98|63\r\n98|26\r\n98|46\r\n98|84\r\n98|22\r\n98|45\r\n72|54\r\n72|48\r\n72|45\r\n72|31\r\n72|12\r\n72|99\r\n72|87\r\n72|75\r\n72|88\r\n72|63\r\n72|78\r\n72|69\r\n72|59\r\n35|87\r\n35|83\r\n35|59\r\n35|75\r\n35|82\r\n35|88\r\n35|99\r\n35|98\r\n35|45\r\n35|47\r\n35|74\r\n35|69\r\n35|97\r\n35|56\r\n43|59\r\n43|33\r\n43|75\r\n43|72\r\n43|54\r\n43|31\r\n43|95\r\n43|24\r\n43|83\r\n43|39\r\n43|16\r\n43|47\r\n43|92\r\n43|44\r\n43|32\r\n17|43\r\n17|26\r\n17|75\r\n17|41\r\n17|79\r\n17|72\r\n17|83\r\n17|39\r\n17|22\r\n17|95\r\n17|46\r\n17|32\r\n17|92\r\n17|47\r\n17|27\r\n17|24\r\n31|16\r\n31|78\r\n31|67\r\n31|22\r\n31|12\r\n31|45\r\n31|17\r\n31|55\r\n31|11\r\n31|82\r\n31|99\r\n31|98\r\n31|63\r\n31|79\r\n31|97\r\n31|56\r\n31|61\r\n85|56\r\n85|36\r\n85|66\r\n85|22\r\n85|48\r\n85|98\r\n85|76\r\n85|43\r\n85|96\r\n85|61\r\n85|67\r\n85|55\r\n85|82\r\n85|84\r\n85|69\r\n85|11\r\n85|17\r\n85|78\r\n75|16\r\n75|63\r\n75|99\r\n75|59\r\n75|97\r\n75|55\r\n75|54\r\n75|82\r\n75|74\r\n75|96\r\n75|88\r\n75|98\r\n75|12\r\n75|36\r\n75|69\r\n75|85\r\n75|45\r\n75|31\r\n75|61\r\n46|75\r\n46|24\r\n46|72\r\n46|77\r\n46|83\r\n46|59\r\n46|88\r\n46|32\r\n46|16\r\n46|39\r\n46|44\r\n46|74\r\n46|31\r\n46|99\r\n46|54\r\n46|87\r\n46|47\r\n46|27\r\n46|35\r\n46|95\r\n39|88\r\n39|78\r\n39|85\r\n39|59\r\n39|83\r\n39|47\r\n39|82\r\n39|92\r\n39|97\r\n39|48\r\n39|72\r\n39|75\r\n39|63\r\n39|45\r\n39|56\r\n39|16\r\n39|87\r\n39|35\r\n39|31\r\n39|99\r\n39|95\r\n96|66\r\n96|35\r\n96|26\r\n96|79\r\n96|87\r\n96|84\r\n96|27\r\n96|11\r\n96|33\r\n96|77\r\n96|95\r\n96|46\r\n96|76\r\n96|39\r\n96|17\r\n96|44\r\n96|47\r\n96|83\r\n96|43\r\n96|41\r\n96|22\r\n96|72\r\n95|75\r\n95|54\r\n95|92\r\n95|98\r\n95|59\r\n95|87\r\n95|16\r\n95|47\r\n95|63\r\n95|12\r\n95|72\r\n95|97\r\n95|85\r\n95|99\r\n95|56\r\n95|48\r\n95|83\r\n95|69\r\n95|74\r\n95|88\r\n95|78\r\n95|31\r\n95|82\r\n47|92\r\n47|45\r\n47|61\r\n47|31\r\n47|54\r\n47|16\r\n47|97\r\n47|98\r\n47|63\r\n47|85\r\n47|78\r\n47|48\r\n47|82\r\n47|12\r\n47|69\r\n47|87\r\n47|88\r\n47|75\r\n47|72\r\n47|83\r\n47|56\r\n47|74\r\n47|99\r\n47|59\r\n74|11\r\n74|12\r\n74|82\r\n74|17\r\n74|16\r\n74|22\r\n74|78\r\n74|85\r\n74|56\r\n74|45\r\n74|96\r\n74|55\r\n74|99\r\n74|76\r\n74|63\r\n74|97\r\n74|69\r\n74|48\r\n74|84\r\n74|31\r\n74|98\r\n74|36\r\n74|61\r\n74|67\r\n22|32\r\n22|87\r\n22|39\r\n22|72\r\n22|43\r\n22|47\r\n22|59\r\n22|79\r\n22|41\r\n22|83\r\n22|35\r\n22|77\r\n22|26\r\n22|88\r\n22|54\r\n22|95\r\n22|24\r\n22|46\r\n22|27\r\n22|44\r\n22|33\r\n22|66\r\n22|75\r\n22|92\r\n78|26\r\n78|96\r\n78|84\r\n78|46\r\n78|22\r\n78|44\r\n78|63\r\n78|45\r\n78|76\r\n78|67\r\n78|55\r\n78|56\r\n78|82\r\n78|61\r\n78|97\r\n78|11\r\n78|43\r\n78|69\r\n78|98\r\n78|12\r\n78|79\r\n78|36\r\n78|17\r\n78|66\r\n27|74\r\n27|75\r\n27|24\r\n27|77\r\n27|54\r\n27|92\r\n27|48\r\n27|31\r\n27|99\r\n27|41\r\n27|59\r\n27|83\r\n27|82\r\n27|72\r\n27|85\r\n27|88\r\n27|16\r\n27|78\r\n27|98\r\n27|39\r\n27|87\r\n27|47\r\n27|95\r\n27|35\r\n45|77\r\n45|44\r\n45|11\r\n45|27\r\n45|79\r\n45|41\r\n45|84\r\n45|96\r\n45|17\r\n45|22\r\n45|55\r\n45|69\r\n45|43\r\n45|61\r\n45|66\r\n45|36\r\n45|67\r\n45|33\r\n45|76\r\n45|46\r\n45|26\r\n45|24\r\n45|32\r\n45|12\r\n76|75\r\n76|87\r\n76|54\r\n76|33\r\n76|41\r\n76|32\r\n76|46\r\n76|35\r\n76|88\r\n76|92\r\n76|22\r\n76|47\r\n76|83\r\n76|95\r\n76|72\r\n76|77\r\n76|44\r\n76|26\r\n76|43\r\n76|39\r\n76|79\r\n76|27\r\n76|24\r\n76|66\r\n83|85\r\n83|69\r\n83|99\r\n83|56\r\n83|63\r\n83|87\r\n83|88\r\n83|98\r\n83|61\r\n83|45\r\n83|48\r\n83|92\r\n83|55\r\n83|16\r\n83|54\r\n83|59\r\n83|74\r\n83|31\r\n83|67\r\n83|12\r\n83|75\r\n83|82\r\n83|97\r\n83|78\r\n56|79\r\n56|11\r\n56|61\r\n56|77\r\n56|69\r\n56|45\r\n56|12\r\n56|84\r\n56|67\r\n56|66\r\n56|63\r\n56|44\r\n56|33\r\n56|17\r\n56|96\r\n56|36\r\n56|43\r\n56|46\r\n56|32\r\n56|27\r\n56|26\r\n56|76\r\n56|55\r\n56|22\r\n63|41\r\n63|96\r\n63|22\r\n63|32\r\n63|36\r\n63|12\r\n63|44\r\n63|67\r\n63|55\r\n63|61\r\n63|33\r\n63|79\r\n63|45\r\n63|26\r\n63|27\r\n63|17\r\n63|11\r\n63|84\r\n63|46\r\n63|69\r\n63|76\r\n63|66\r\n63|77\r\n63|43\r\n16|26\r\n16|99\r\n16|85\r\n16|61\r\n16|56\r\n16|98\r\n16|22\r\n16|82\r\n16|78\r\n16|12\r\n16|84\r\n16|17\r\n16|96\r\n16|36\r\n16|45\r\n16|63\r\n16|76\r\n16|11\r\n16|69\r\n16|48\r\n16|55\r\n16|79\r\n16|97\r\n16|67\r\n82|67\r\n82|76\r\n82|45\r\n82|17\r\n82|36\r\n82|46\r\n82|79\r\n82|11\r\n82|69\r\n82|84\r\n82|55\r\n82|96\r\n82|22\r\n82|66\r\n82|44\r\n82|97\r\n82|26\r\n82|12\r\n82|56\r\n82|98\r\n82|43\r\n82|63\r\n82|32\r\n82|61\r\n79|35\r\n79|83\r\n79|54\r\n79|47\r\n79|59\r\n79|24\r\n79|92\r\n79|39\r\n79|88\r\n79|77\r\n79|33\r\n79|26\r\n79|44\r\n79|66\r\n79|46\r\n79|87\r\n79|95\r\n79|43\r\n79|75\r\n79|74\r\n79|41\r\n79|32\r\n79|27\r\n79|72\r\n54|61\r\n54|69\r\n54|45\r\n54|99\r\n54|82\r\n54|88\r\n54|17\r\n54|16\r\n54|98\r\n54|78\r\n54|56\r\n54|36\r\n54|63\r\n54|11\r\n54|31\r\n54|59\r\n54|85\r\n54|67\r\n54|74\r\n54|55\r\n54|48\r\n54|12\r\n54|97\r\n54|96\r\n32|54\r\n32|85\r\n32|33\r\n32|92\r\n32|59\r\n32|72\r\n32|75\r\n32|95\r\n32|31\r\n32|39\r\n32|87\r\n32|83\r\n32|35\r\n32|16\r\n32|78\r\n32|24\r\n32|88\r\n32|48\r\n32|47\r\n32|77\r\n32|74\r\n32|99\r\n32|41\r\n32|27\r\n44|88\r\n44|85\r\n44|83\r\n44|32\r\n44|47\r\n44|48\r\n44|95\r\n44|31\r\n44|99\r\n44|59\r\n44|41\r\n44|27\r\n44|35\r\n44|54\r\n44|16\r\n44|24\r\n44|75\r\n44|72\r\n44|92\r\n44|77\r\n44|39\r\n44|33\r\n44|74\r\n44|87\r\n87|45\r\n87|75\r\n87|59\r\n87|88\r\n87|61\r\n87|92\r\n87|69\r\n87|97\r\n87|82\r\n87|31\r\n87|99\r\n87|12\r\n87|48\r\n87|54\r\n87|74\r\n87|36\r\n87|85\r\n87|56\r\n87|63\r\n87|67\r\n87|55\r\n87|98\r\n87|78\r\n87|16\r\n55|44\r\n55|66\r\n55|96\r\n55|76\r\n55|39\r\n55|24\r\n55|77\r\n55|22\r\n55|43\r\n55|84\r\n55|17\r\n55|11\r\n55|46\r\n55|33\r\n55|67\r\n55|95\r\n55|27\r\n55|79\r\n55|35\r\n55|32\r\n55|47\r\n55|41\r\n55|36\r\n55|26\r\n67|46\r\n67|17\r\n67|33\r\n67|72\r\n67|96\r\n67|35\r\n67|36\r\n67|79\r\n67|39\r\n67|66\r\n67|41\r\n67|27\r\n67|11\r\n67|44\r\n67|43\r\n67|26\r\n67|76\r\n67|47\r\n67|84\r\n67|22\r\n67|95\r\n67|77\r\n67|32\r\n67|24\r\n97|17\r\n97|69\r\n97|12\r\n97|84\r\n97|67\r\n97|56\r\n97|11\r\n97|32\r\n97|26\r\n97|27\r\n97|45\r\n97|96\r\n97|22\r\n97|55\r\n97|43\r\n97|46\r\n97|36\r\n97|61\r\n97|33\r\n97|66\r\n97|63\r\n97|44\r\n97|79\r\n97|76\r\n66|32\r\n66|99\r\n66|33\r\n66|87\r\n66|83\r\n66|92\r\n66|74\r\n66|44\r\n66|59\r\n66|41\r\n66|77\r\n66|54\r\n66|16\r\n66|39\r\n66|31\r\n66|27\r\n66|95\r\n66|47\r\n66|35\r\n66|72\r\n66|24\r\n66|75\r\n66|88\r\n66|46\r\n26|27\r\n26|33\r\n26|66\r\n26|32\r\n26|44\r\n26|41\r\n26|72\r\n26|88\r\n26|75\r\n26|74\r\n26|46\r\n26|95\r\n26|54\r\n26|43\r\n26|83\r\n26|47\r\n26|77\r\n26|39\r\n26|92\r\n26|24\r\n26|35\r\n26|31\r\n26|59\r\n26|87\r\n99|79\r\n99|63\r\n99|36\r\n99|43\r\n99|96\r\n99|48\r\n99|26\r\n99|78\r\n99|85\r\n99|12\r\n99|69\r\n99|76\r\n99|17\r\n99|82\r\n99|56\r\n99|61\r\n99|97\r\n99|45\r\n99|67\r\n99|84\r\n99|11\r\n99|98\r\n99|22\r\n99|55\r\n12|77\r\n12|22\r\n12|33\r\n12|36\r\n12|17\r\n12|96\r\n12|41\r\n12|11\r\n12|27\r\n12|26\r\n12|76\r\n12|39\r\n12|84\r\n12|35\r\n12|43\r\n12|55\r\n12|24\r\n12|66\r\n12|61\r\n12|79\r\n12|46\r\n12|44\r\n12|32\r\n12|67\r\n77|39\r\n77|48\r\n77|41\r\n77|99\r\n77|59\r\n77|82\r\n77|85\r\n77|75\r\n77|72\r\n77|54\r\n77|47\r\n77|95\r\n77|78\r\n77|31\r\n77|16\r\n77|83\r\n77|24\r\n77|92\r\n77|35\r\n77|74\r\n77|87\r\n77|97\r\n77|98\r\n77|88\r\n61|17\r\n61|43\r\n61|36\r\n61|95\r\n61|41\r\n61|46\r\n61|66\r\n61|33\r\n61|67\r\n61|55\r\n61|27\r\n61|22\r\n61|77\r\n61|24\r\n61|35\r\n61|96\r\n61|39\r\n61|79\r\n61|32\r\n61|76\r\n61|84\r\n61|44\r\n61|26\r\n61|11\r\n84|83\r\n84|35\r\n84|26\r\n84|47\r\n84|22\r\n84|46\r\n84|27\r\n84|92\r\n84|54\r\n84|33\r\n84|44\r\n84|43\r\n84|66\r\n84|32\r\n84|77\r\n84|87\r\n84|79\r\n84|72\r\n84|76\r\n84|95\r\n84|75\r\n84|41\r\n84|24\r\n48|69\r\n48|82\r\n48|97\r\n48|61\r\n48|96\r\n48|12\r\n48|67\r\n48|22\r\n48|78\r\n48|45\r\n48|66\r\n48|76\r\n48|98\r\n48|17\r\n48|84\r\n48|55\r\n48|46\r\n48|36\r\n48|56\r\n48|43\r\n48|63\r\n48|26\r\n88|16\r\n88|11\r\n88|96\r\n88|59\r\n88|85\r\n88|45\r\n88|31\r\n88|74\r\n88|69\r\n88|36\r\n88|63\r\n88|48\r\n88|55\r\n88|78\r\n88|67\r\n88|61\r\n88|99\r\n88|97\r\n88|84\r\n88|17\r\n88|56\r\n69|24\r\n69|79\r\n69|12\r\n69|96\r\n69|66\r\n69|44\r\n69|33\r\n69|26\r\n69|32\r\n69|36\r\n69|84\r\n69|41\r\n69|17\r\n69|11\r\n69|43\r\n69|39\r\n69|27\r\n69|55\r\n69|76\r\n69|46\r\n41|98\r\n41|85\r\n41|99\r\n41|35\r\n41|24\r\n41|16\r\n41|88\r\n41|97\r\n41|92\r\n41|54\r\n41|48\r\n41|39\r\n41|72\r\n41|87\r\n41|47\r\n41|74\r\n41|78\r\n41|82\r\n41|31\r\n24|88\r\n24|59\r\n24|78\r\n24|99\r\n24|74\r\n24|72\r\n24|85\r\n24|39\r\n24|56\r\n24|35\r\n24|75\r\n24|95\r\n24|92\r\n24|63\r\n24|31\r\n24|82\r\n24|87\r\n24|83\r\n33|99\r\n33|24\r\n33|85\r\n33|41\r\n33|27\r\n33|74\r\n33|77\r\n33|48\r\n33|83\r\n33|39\r\n33|95\r\n33|31\r\n33|75\r\n33|54\r\n33|72\r\n33|35\r\n33|87\r\n92|55\r\n92|85\r\n92|16\r\n92|96\r\n92|12\r\n92|36\r\n92|31\r\n92|45\r\n92|98\r\n92|69\r\n92|99\r\n92|11\r\n92|61\r\n92|48\r\n92|67\r\n92|54\r\n11|66\r\n11|72\r\n11|17\r\n11|87\r\n11|95\r\n11|46\r\n11|44\r\n11|26\r\n11|33\r\n11|22\r\n11|84\r\n11|76\r\n11|41\r\n11|32\r\n11|83\r\n36|95\r\n36|77\r\n36|43\r\n36|84\r\n36|24\r\n36|17\r\n36|11\r\n36|27\r\n36|32\r\n36|79\r\n36|47\r\n36|41\r\n36|22\r\n36|66\r\n59|56\r\n59|48\r\n59|16\r\n59|11\r\n59|82\r\n59|85\r\n59|63\r\n59|99\r\n59|96\r\n59|45\r\n59|74\r\n59|98\r\n59|31\r\n98|12\r\n98|44\r\n98|36\r\n98|33\r\n98|56\r\n98|76\r\n98|11\r\n98|96\r\n98|69\r\n98|79\r\n98|43\r\n98|17\r\n72|56\r\n72|55\r\n72|74\r\n72|16\r\n72|97\r\n72|82\r\n72|85\r\n72|83\r\n72|92\r\n72|98\r\n72|61\r\n35|63\r\n35|16\r\n35|92\r\n35|31\r\n35|85\r\n35|78\r\n35|48\r\n35|95\r\n35|72\r\n35|54\r\n43|35\r\n43|74\r\n43|88\r\n43|77\r\n43|66\r\n43|27\r\n43|41\r\n43|46\r\n43|87\r\n17|35\r\n17|84\r\n17|77\r\n17|44\r\n17|87\r\n17|33\r\n17|76\r\n17|66\r\n31|48\r\n31|84\r\n31|36\r\n31|69\r\n31|96\r\n31|76\r\n31|85\r\n85|12\r\n85|97\r\n85|63\r\n85|26\r\n85|45\r\n85|79\r\n75|78\r\n75|92\r\n75|67\r\n75|56\r\n75|48\r\n46|92\r\n46|33\r\n46|41\r\n46|85\r\n39|98\r\n39|74\r\n39|54\r\n96|32\r\n96|24\r\n95|45\r\n\r\n26,46,44,33,77,41,39,95,47,83,75,54,88,59,74\r\n63,61,11,79,26,44,32,33,77\r\n72,92,16,48,98\r\n48,82,59,85,55\r\n66,84,76,33,79,75,92,41,44,46,35\r\n63,69,61,55,67,36,11,84,76,22,26,46,44,32,33,27,77\r\n33,77,17,32,24,26,11,61,43,79,46,76,84,22,12,41,96,27,55,67,36,44,39\r\n11,17,84,76,79,26,43,66,46,44,32,33,77,41,24,95,47,83,87\r\n27,77,41,24,39,35,95,72,83,87,75,92,54,88,74,31,99,85,48,78,82\r\n87,75,54,88,59,74,31,99,48,78,97,56,63,45,69,12,61,55,67\r\n46,17,66,76,77,67,26,35,61,96,22,44,11,24,27\r\n39,35,72,83,87,75,92,59,74,31,99,85,48,78,82,98,63\r\n24,27,17,76,79,44,26,32,35\r\n98,88,63,45,56,72,78,85,82,12,69,59,87,54,47,75,31,83,48,16,74,99,92\r\n67,17,84,76,22,79,43,46,32,33,24,35,47\r\n78,27,33,24,85,74,92,54,75,95,48,99,39\r\n95,47,72,83,87,75,92,54,88,74,31,16,99,85,48,98,97,56,63,45,69\r\n83,16,77,35,59,31,46,27,74,92,39,66,87,54,41,33,75,44,95\r\n72,33,39,88,54,26,27,24,41,22,92,35,46,87,44,83,43,77,75,32,79,95,66\r\n79,36,41,46,44,72,35,27,17\r\n84,26,66,32,33,35,95,72,92\r\n31,16,45,69,61,12,74,17,82,85,11,88,48,98,67,63,99,56,96,78,36\r\n78,87,16,95,35,45,85\r\n61,55,67,36,96,11,17,84,76,26,43,66,46,33,27,77,41,24,39\r\n56,78,99,69,47,16,98,92,72,83,75,74,82,45,31,85,63,12,48\r\n54,59,95,31,92,87,16\r\n72,87,24,92,59,95,47,75,88,41,99,82,16,85,39\r\n17,22,26,84,67,55,36,11,61,79,69,97,76\r\n77,26,11,32,43,66,63,33,44,67,76\r\n77,85,47,99,44,31,95,27,87,35,54,16,74,39,83,59,41,32,24\r\n47,72,83,87,75,92,54,59,74,85,48,78,82,98,97,56,63,69,12\r\n74,31,48,78,98,56,45,69,61,11,84\r\n26,11,97,56,67,66,69,32,17,43,55,36,33,22,79,76,96,61,45,44,12,84,63\r\n72,83,77,92,27,75,41,35,44,33,54,43,46,79,26,47,22,66,24\r\n95,41,44,59,66,88,35,77,27,79,43,72,26,47,92,46,54,33,83\r\n45,69,12,55,67,36,96,11,17,84,76,22,26,43,66,46,44,32,27,77,41\r\n48,98,56,69,36,76,79,43,66\r\n84,77,35,83,44,39,66,75,72,27,79,26,17,24,43,76,87,22,46,47,95,32,33\r\n69,74,92,98,59,63,99,83,72,45,47,95,54,87,48\r\n92,56,96,59,74,69,85,99,98\r\n11,84,76,26,43,66,46,44,32,33,27,77,41,24,39,35,95,83,87\r\n97,67,11,76,79,43,66,32,33\r\n66,44,27,77,24,39,35,95,72,83,75,88,74,31,16\r\n36,11,76,43,44\r\n88,97,63,98,56,87,75,99,59,35,48,92,95,83,78,54,47\r\n76,77,32,55,27,79,46,66,17,12,69,43,45,84,44,41,33\r\n77,41,27,92,99,75,24,44,46,59,32\r\n76,24,12,32,96,79,77,36,84\r\n77,24,35,72,83,87,75,92,88,59,31,16,85,82,98\r\n67,77,39,22,84,47,46,41,44,26,95,35,27,76,66,11,79,96,33,24,43\r\n69,12,61,36,96,84,76,22,79,26,43,46,33,41,24\r\n46,96,78,22,26,11,76\r\n47,72,92,88,59,74,16,78,82,98,56,63,12\r\n75,92,54,59,74,31,99,85,48,56,63,69,12,67,36\r\n43,54,44,35,77,26,92,76,47\r\n87,92,54,88,59,74,31,16,99,85,48,78,82,98,56,63,45,69,12,61,55\r\n36,11,17,24,66,32,84,61,77\r\n33,24,22,35,47,83,76,77,92,66,54,44,75,32,41,26,46,87,79\r\n63,36,96,11,17,26,46,44,77\r\n87,92,47,75,32,27,16,33,39,44,41,72,88,46,77,59,95,54,99,35,24\r\n22,26,43,66,46,32,33,27,95,83,75,54,88\r\n76,96,82,97,98,61,44\r\n84,82,17,99,67,48,11,85,12,22,69,96,55\r\n46,32,41,39,95,75,54,16,99\r\n87,92,16,99,78,98,56\r\n45,61,74,12,11,76,67\r\n46,27,32,77,92,88,47,31,99\r\n63,85,26,97,82,36,17,56,48,22,45,99,61,84,78\r\n41,48,95,77,82,31,74,85,72,88,35,99,27,39,78,24,92\r\n61,87,92,55,31,69,67,56,88,16,48,97,74,54,63\r\n44,32,27,77,41,24,35,95,47,72,83,87,75,54,88,59,74,31,16,99,85\r\n79,66,46,32,27\r\n54,56,97,83,95,24,82,31,85,88,35,16,92\r\n26,17,45,12,43,96,48\r\n99,48,82,56,63,45,69,61,55,67,17,76,79\r\n66,16,72,27,88,77,44\r\n98,97,56,63,45,12,61,55,36,96,11,17,22,79,26,66,46,44,32\r\n39,35,95,47,72,83,87,75,92,54,88,59,74,31,99,85,48,78,82,98,97,56,63\r\n56,69,85,67,11,43,96,17,55,76,26,84,45\r\n54,59,16,99,78,82,11\r\n63,84,61,97,11,79,16,67,99,82,96,22,76,56,36\r\n39,59,72,33,83,95,48,74,87,16,41,54,77,85,35,92,47,78,31,88,99\r\n98,97,56,12,61,36,96,11,17,84,22,79,26,43,46,44,32\r\n84,76,22,79,26,43,32,27,77,41,47,72,92\r\n69,12,61,55,96,11,17,84,22,79,26,43,66,46,44,32,33,27,77,41,24\r\n79,82,66,48,76,22,17,55,45,67,36,63,43,98,11,61,78\r\n54,88,59,74,31,16,99,85,48,78,82,98,97,63,45,69,12,61,55,67,36,96,11\r\n45,61,97,99,72,74,12\r\n95,47,72,54,88,59,31,16,99,85,48,98,97,56,69\r\n83,87,75,92,54,88,59,74,31,16,99,85,48,82,98,97,63,45,69,12,55\r\n56,98,31,54,16,83,48,35,92,24,95,78,87\r\n82,98,97,45,12,61,55,67,36,96,11,17,84,76,22,79,43,66,44\r\n79,26,43,46,33,27,77,41,24,39,95,47,83,87,75,88,59\r\n78,16,97,56,61,67,11,48,99,22,31,82,17,69,96\r\n56,98,69,63,78,55,31,16,83\r\n46,76,79,44,77,55,84,36,26,33,12,39,43,67,17\r\n26,92,41,83,87,75,35,43,46,88,32,33,44,47,77,24,27,72,39,95,59\r\n85,96,97,74,48,11,55,69,36,31,59,63,82,16,45,17,99,67,61,12,98\r\n46,66,92,33,39,27,47,44,72\r\n11,99,67,55,63,97,48,69,74\r\n88,32,75,41,72,74,33,44,39,31,95,47,54,87,83,16,59\r\n72,83,92,48,98,97,61\r\n31,69,12,36,98,97,85,11,61,48,82\r\n77,59,27,26,32,24,92,83,35,87,66,39,41,46,74,88,54,95,44\r\n82,56,69,36,11\r\n55,56,74,96,45\r\n46,17,69,32,76,97,43,33,22\r\n36,96,17,84,76,22,79,26,46,44,32,27,77,41,24,39,35,47,72\r\n69,55,26,66,77,41,24\r\n98,75,78,95,16,35,87,88,47,99,39,82,48,56,63,59,92,97,31,83,54\r\n36,17,85,59,55,78,12,56,96,11,84,67,63,61,74,45,99,31,97\r\n99,97,87,82,16,63,88,12,74,98,56,45,92,69,75,78,59,55,61,54,67,31,48\r\n79,67,55,11,63,46,17,69,43,44,26,97,45,61,76,36,98\r\n17,36,84,16,74,12,67,11,76,78,96,97,82,61,45\r\n11,66,96,79,67,35,39,22,84,33,76,55,43,27,61,44,24,36,32\r\n27,72,78,77,33,85,39\r\n27,17,32,67,36,33,69,43,12,61,66,24,11,77,96\r\n78,56,31,82,39,74,92\r\n78,82,98,97,36,84,46\r\n31,99,78,12,96,11,17,84,22\r\n77,35,95,54,83,87,43,41,72,39,92,22,79,44,66,26,46\r\n66,24,84,27,61\r\n43,77,33,54,95,88,46,26,75,92,32,74,66,24,47,72,83,59,35,44,41\r\n27,77,41,24,39,35,95,47,72,83,87,75,92,54,88,59,31,16,99,85,48,78,82\r\n88,59,74,31,16,99,48,82,98,56,63,45,69,12,61,67,96,11,17\r\n85,88,36,75,56,98,82,45,59,78,54,74,92,16,67\r\n95,76,24,55,84,27,77,33,26,35,67,44,11,17,43\r\n97,22,11,78,84,69,26,85,82,55,98,17,48,12,36,61,76,96,43,56,45,67,79\r\n78,97,56,45,69,61,67,96,17,76,22,79,46\r\n59,97,31,61,98,88,74,54,85,55,48,12,83,87,16,99,78,75,45\r\n24,39,35,95,47,72,83,87,75,92,54,88,59,74,31,16,99,48,78,82,98,97,56\r\n43,66,46,44,32,27,77,41,24,39,35,95,47,72,83,87,92,88,59,74,31\r\n82,98,97,56,63,45,61,55,67,36,96,11,17,84,76,22,26,43,66,46,44\r\n88,54,27,83,41\r\n69,75,31,47,56,45,95\r\n11,84,22,66,27\r\n59,16,99,48,82,98,97,56,63,69,12,61,55,67,96,17,84\r\n31,98,39,16,78,24,85,72,87,56,48,95,99\r\n32,33,27,35,72,87,54,74,31\r\n43,33,27,24,39,72,31\r\n87,74,47,16,54,72,45,56,97,82,31,75,83,59,35,48,98,92,63\r\n61,55,67,36,96,11,17,76,22,79,26,43,66,46,44,32,33,27,77,41,24,39,35\r\n33,84,72,79,24,95,41,36,27\r\n41,24,35,95,47,87,92,54,88,59,31,16,99,85,82\r\n97,56,45,79,76,16,36,17,61,11,22\r\n82,45,97,98,16,61,67,54,88,48,63,78,74,12,99,96,31,85,11\r\n17,22,66,44,77,41,35,95,75\r\n96,17,84,76,22,79,43,46,44,32,27,77,41,24,39,35,95,47,83\r\n85,98,56,11,45,96,78,63,69,31,22,67,36\r\n72,16,99,24,27,87,41,47,39,54,75,44,92,77,33,74,31,59,88,32,46,35,95\r\n26,43,32,33,27,39,72,54,88,59,74\r\n69,61,55,67,96,11,84,22,79,66,46,32,33\r\n88,48,75,59,31,54,56,82,74,92,45,78,12,55,87\r\n74,31,16,99,85,48,78,82,98,97,56,63,45,69,12,61,55,67,96,11,17,84,76\r\n11,43,78,46,61,55,96\r\n72,83,92,54,88,74,31,16,85,48,78,98,63,69,61\r\n76,41,33,36,11,77,24,39,84,66,61,27,67,55,17,22,35,44,32,79,26\r\n48,11,82,96,97,45,16\r\n32,33,27,35,47,72,83,92,54,88,74,31,99,85,48\r\n48,82,98,56,63,45,69,61,67,96,76,79,26,43,66\r\n66,41,33,32,27,36,96,43,11,79,24,17,95,46,84,44,35,76,39,67,47\r\n54,74,85,78,97\r\n39,35,95,47,72,83,87,75,54,88,59,74,31,16,99,85,48,78,82,98,97,56,63\r\n88,31,16,48,78,98,97,63,12,61,36,96,17\r\n47,31,39,43,54,77,66,35,44,59,72,92,24,32,95,88,33,27,46\r\n11,17,84,26,66,46,44,32,33,27,41,24,39,47,72,83,87\r\n82,97,55,17,84,43,44\r\n67,82,99,87,63,61,88,55,48,69,45\r\n67,69,84,24,55,41,11\r\n75,16,45,12,55,67,36\r\n74,31,48,97,12,96,17,84,76\r\n83,72,66,24,46,96,17,35,79,22,43,44,32\r\n35,95,47,72,83,92,54,88,74,85,78,97,56,63,45\r\n46,77,87,39,35,22,47,95,33,44,92\r\n75,41,59,74,43,95,24,72,26,77,32,44,66\r\n36,96,84,79,26,66,46,32,33,27,77,41,39,35,95,47,72\r\n35,87,33,46,22,92,88,79,47,41,24,44,32,72,54,43,27,83,39,95,66\r\n36,11,17,26,41\r\n84,76,22,79,43,33,27,77,24,35,95,75,92\r\n11,79,66,27,39,95,87\r\n39,24,32,26,12,17,44\r\n84,43,83,35,41,76,22,32,46,27,79,87,92,47,24\r\n61,43,22,84,67,36,46,78,63,12,11,96,17\r\n77,41,24,39,95,83,87,54,74,31,48,82,98\r\n59,98,78,75,97,63,45,61,88,72,99,82,69\r\n78,67,55,74,63,56,31,36,92,12,45\r\n63,45,67,96,26,43,66,44,77\r\n96,36,77,22,76,61,27,12,55,39,33,79,26,84,32,43,67\r\n82,98,69,16,75,85,78,67,87,12,63,56,99\r\n82,96,54,63,69,99,55,74,11\r\n95,47,72,83,87,92,54,88,59,74,31,16,99,48,97,63,69\r\n11,84,22,79,26,66,46,44,32,33,27,77,41,24,39,35,95,47,72,83,87\r\n41,92,99,31,82,72,24,98,88,48,16,47,78,74,59,95,97,75,85,35,87\r\n72,83,75,92,54,59,74,31,16,85,48,82,98,97,63,45,69,12,61";
        public string ExampleInput = "47|53\r\n97|13\r\n97|61\r\n97|47\r\n75|29\r\n61|13\r\n75|53\r\n29|13\r\n97|29\r\n53|29\r\n61|53\r\n97|53\r\n61|29\r\n47|13\r\n75|47\r\n97|75\r\n47|61\r\n75|61\r\n47|29\r\n75|13\r\n53|13\r\n\r\n75,47,61,53,29\r\n97,61,53,29,13\r\n75,29,13\r\n75,97,47,61,53\r\n61,13,29\r\n97,13,75,29,47";

        public string TestInput = "5|2\n3|2\n4|3\n4|5\n1|4\n\n1,2,3,4,5\n1,4,3,5,2";
        public void Run()
        {
            //SolvePart1();
            SolvePart2();
        }

        public void SolvePart1()
        {
            var (orderRules, updates) = ParseInput(InputStr);

            // get all valid updates
            var validUpdates = new List<List<int>>();

            foreach (var update in updates)
            {
                var isValid = true;
                foreach (var orderRule in orderRules)
                {
                    if (!orderRule.IsOrderRuleActive(update))
                    {
                        isValid = false;
                        break;
                    }
                }

                if (isValid)
                {
                    validUpdates.Add(update);
                }
            }

            var result = 0;
            validUpdates.ForEach(update => result += update[update.Count / 2]);

            Console.WriteLine($"[Day 5 - Part 1]\nThe sum of correct middle values is = {result}");
        }

        public void SolvePart2()
        {
            var (orderRules, updates) = ParseInputAdvancedRules(InputStr);

            // get all invalid updates
            var invalidUpdates = new List<List<int>>();
            foreach (var update in updates)
            {

                foreach (KeyValuePair<int, AdvancedOrderRule> orderRule in orderRules)
                {
                    if (!orderRule.Value.IsRuleActive(update))
                    {
                        invalidUpdates.Add(update);
                        break;
                    }
                }
            }

            // reoder invalid updates
            var middleValueSum = 0;
            foreach (var update in invalidUpdates)
            {
                var suggestedMoves = GenerateMovesForUpdate(update, orderRules);
                var res = FindCorrectOrder(update, orderRules);
                middleValueSum += res[res.Count / 2];
                Console.WriteLine($"[{string.Join(",", res)}] => {res[res.Count / 2]}");
            }
            Console.WriteLine($"[Day 5 - Part 2]\nThe sum of correct middle values is = {middleValueSum}");
        }

        public Tuple<List<OrderRule>, List<List<int>>> ParseInput(string input)
        {
            // split input into the orders and updates
            var splitInput = input.Replace("\r", "").Split(new[] { "\n\n" }, StringSplitOptions.None);

            // get the order rules
            var orderRules = new List<OrderRule>();
            splitInput[0].Split('\n').ToList().ForEach(line => orderRules.Add(new OrderRule(line)));

            // get the updates
            var updates = new List<List<int>>();
            splitInput[1].Split('\n').ToList().ForEach(line => updates.Add(line.Split(',').ToList().Select(nr => int.Parse(nr)).ToList()));

            return new Tuple<List<OrderRule>, List<List<int>>>(orderRules, updates);
        }

        public Tuple<Dictionary<int, AdvancedOrderRule>, List<List<int>>> ParseInputAdvancedRules(string input)
        {
            // split input into the orders and updates
            var splitInput = input.Replace("\r", "").Split(new[] { "\n\n" }, StringSplitOptions.None);

            // get the order rules
            Dictionary<int, AdvancedOrderRule> rules = new Dictionary<int, AdvancedOrderRule>();
            foreach (var rule in splitInput[0].Split('\n').ToList())
            {
                var _rule = rule.Split('|');
                var key = int.Parse(_rule[0]);

                if (rules.ContainsKey(key))
                {
                    rules[key].AddMarker(int.Parse(_rule[1]));
                }
                else
                {
                    rules.Add(key, new AdvancedOrderRule(key, int.Parse(_rule[1])));
                }
            }

            // get the updates
            var updates = new List<List<int>>();
            splitInput[1].Split('\n').ToList().ForEach(line => updates.Add(line.Split(',').ToList().Select(nr => int.Parse(nr)).ToList()));

            return new Tuple<Dictionary<int, AdvancedOrderRule>, List<List<int>>>(rules, updates);
        }

        public List<int> ApplyMoves(List<int> update, Dictionary<int, List<int>> moves, Dictionary<int, AdvancedOrderRule> orderRules)
        {
            // copy the update inorder to update it in the loops
            var updateCopy = update.ToList();

            // use this function to execute the first move of a rule
            var executeMove = new Action<KeyValuePair<int, List<int>>>((entry) =>
            {
                // Assuming updateCopy is available in the current scope
                updateCopy.RemoveAt(updateCopy.FindLastIndex(x => x == entry.Key));

                // Move the number to the new position
                updateCopy.Insert(entry.Value[0], entry.Key);

                // Remove the number from the set of moves
                moves.Remove(entry.Key);

                // Remove the position from all other numbers
                moves = UpdateMoves(moves, entry.Value[0]);
            });

            while (!IsUpdateValid(updateCopy, orderRules) && moves.Count > 0)
            {
                var copy = moves.ToList();
                var updatedMoves = false;
                foreach (KeyValuePair<int, List<int>> entry in copy)
                {
                    // check if a number can only be at one position
                    if (entry.Value.Count == 1)
                    {
                        executeMove(entry);

                        // restart the check
                        updatedMoves = true;
                        break;
                    }
                }

                if (!updatedMoves)
                {
                    //  execute one move, if no other moves were found.
                    executeMove(moves.First());

                    // FIXME this doesnt work, as it will just give the same input as was the case when the if was entered!
                    //  After that, regenerate the moveset
                    moves = GenerateMovesForUpdate(updateCopy, orderRules);
                }
            }

            return updateCopy;


            //while (!IsUpdateValid(updateCopy, orderRules) && moves.Count > 0)
            //{
            //    var copy = moves.ToList();
            //    foreach (KeyValuePair<int, List<int>> entry in copy)
            //    {
            //        if (entry.Value == null) { continue; }

            //        // remove the old value
            //        updateCopy.RemoveAt(updateCopy.FindLastIndex(x => x == entry.Key));

            //        if (entry.Value.Count == 1)
            //        {
            //            updateCopy.Insert(entry.Value[0], entry.Key);
            //            moves.Remove(entry.Key);
            //        }
            //        else
            //        {
            //            // index out of range
            //            updateCopy.Insert(entry.Value[0], entry.Key);
            //            entry.Value.RemoveAt(0);
            //            moves[entry.Key] = entry.Value.ToList();
            //        }


            //    }
            //}
        }

        private List<int> FindCorrectOrder(List<int> update, Dictionary<int, AdvancedOrderRule> orderRules)
        {
            // go through each rule that can be applied
            // > move the key to the left of the smalles marker index
            // check if the update is valid, else restart the loop

            var updateCopy = update.ToList();
            var allowedFullLoops = 10;

            while (allowedFullLoops >= 0)
            {
                allowedFullLoops--;

                foreach (KeyValuePair<int, AdvancedOrderRule> order in orderRules)
                {
                    // skip orders that are not applicable, or already fulfilled
                    if (!updateCopy.Contains(order.Key) || order.Value.IsRuleActive(updateCopy)) continue;

                    // find the smalles makrer position
                    var markerPositions = new List<int>();
                    order.Value.Markers.Where(marker => updateCopy.Contains(marker)).ToList().ForEach(marker => markerPositions.Add(updateCopy.FindIndex(x => x == marker)));

                    // move the key to the correct position
                    updateCopy.Remove(order.Key);
                    updateCopy.Insert(markerPositions.Min() - 1 >= 0 ? markerPositions.Min() - 1 : 0, order.Key);

                    // check if the update is valid after the move
                    if (IsUpdateValid(updateCopy, orderRules)) return updateCopy;
                }
            }

            return updateCopy;
        }

        private bool IsUpdateValid(List<int> update, Dictionary<int, AdvancedOrderRule> orderRules)
        {
            foreach (var orderRule in orderRules)
            {
                if (!orderRule.Value.IsRuleActive(update))
                {
                    return false;
                }
            }

            return true;
        }

        private Dictionary<int, List<int>> UpdateMoves(Dictionary<int, List<int>> moves, int removedIndex)
        {
            var copy = new Dictionary<int, List<int>>(moves);
            foreach (var move in moves)
            {
                copy[move.Key] = move.Value.Where(x => x != removedIndex).ToList();
            }

            return copy;
        }

        private Dictionary<int, List<int>> GenerateMovesForUpdate(List<int> update, Dictionary<int, AdvancedOrderRule> orderRules)
        {
            var suggestedMoves = new Dictionary<int, List<int>>();
            foreach (var orderRule in orderRules)
            {
                var positionList = orderRule.Value.GetPossiblePositions(update);

                if (positionList != null)
                {
                    if (suggestedMoves.ContainsKey(orderRule.Key))
                    {
                        suggestedMoves[orderRule.Key] = suggestedMoves[orderRule.Key].Union(positionList).Distinct().ToList();
                    }
                    else
                    {
                        suggestedMoves[orderRule.Key] = positionList;
                    }
                }
            }

            return suggestedMoves;
        }
    }

    internal class OrderRule
    {
        public int earlier { get; set; }
        public int later { get; set; }

        public OrderRule(int earlier, int later)
        {
            this.earlier = earlier;
            this.later = later;
        }

        public OrderRule(string orderRuleLine)
        {
            var line = orderRuleLine.Split('|');
            earlier = int.Parse(line[0]);
            later = int.Parse(line[1]);
        }


        public bool IsOrderRuleActive(List<int> update)
        {
            var earlyIndex = update.FindIndex(x => x == earlier);
            var laterIndex = update.FindIndex(x => x == later);

            return (earlyIndex == -1 || laterIndex == -1) || earlyIndex < laterIndex;
        }

        public string ToString()
        {
            return $"{earlier}|{later}";
        }

        public List<int> SuggestedEarlierPosition(List<int> update)
        {
            // make no suggestion, if the rule cannot need be applied / the update is correct
            if (IsOrderRuleActive(update)) return null;

            var laterIndex = update.FindIndex(x => x == later);

            var result = new List<int>() { laterIndex };

            while (laterIndex > 0)
            {
                result.Add(--laterIndex);
            }

            return result;
        }


    }


    internal class AdvancedOrderRule
    {
        public int Key { get; set; }

        public List<int> Markers { get; set; }

        public AdvancedOrderRule(int key, int marker)
        {
            Key = key;
            Markers = new List<int> { marker };
        }

        public void AddMarker(int marker)
        {
            Markers.Add(marker);
        }

        public List<int> GetPossiblePositions(List<int> update)
        {
            var activeMarkers = Markers.Where(marker => update.Contains(marker)).ToList();
            var maxResult = Enumerable.Range(0, update.Count).ToList();

            // no rule can be applied -> Key can be everywhere in the update
            if (!update.Contains(Key) /*|| activeMarkers.Count == 0*/)
            {
                return null;
            }

            // key is allowed to be anywhere in the update
            if (activeMarkers.Count == 0)
            {
                return maxResult;
            }

            // get each possible position for an active rule and remove all indexes that are not allowed by all rules
            foreach (var marker in activeMarkers)
            {
                var markerIndex = update.FindIndex(x => x == marker);
                var positionForMarker = Enumerable.Range(0, markerIndex).ToList();
                positionForMarker.Add(markerIndex);

                maxResult = maxResult.Intersect(positionForMarker).ToList();
            }

            return maxResult.Count > 0 ? maxResult : new List<int> { 0 };
        }

        public List<List<int>> PlaceRuleInUpdate(List<int> update)
        {
            // get a copy of the update without the key
            var updateCopy = update.ToList().Where(x => x != Key);
            var activeMarkers = Markers.Where(marker => update.Contains(marker)).ToList();

            var completedUpdates = new List<List<int>>();

            // get each possible position for an active rule and remove all indexes that are not allowed by all rules
            foreach (var marker in activeMarkers)
            {
                var markerIndex = update.FindIndex(x => x == marker);
                var positionForMarker = Enumerable.Range(0, markerIndex).ToList();
                positionForMarker.Add(markerIndex);

                foreach (var pos in positionForMarker)
                {
                    var l = updateCopy.ToList();
                    l.Insert(pos, Key);
                    completedUpdates.Add(l);
                }
            }

            // remove all duplicates
            completedUpdates = completedUpdates.Distinct().ToList();
            return completedUpdates;
        }

        public bool IsRuleActive(List<int> update)
        {
            var keyIndex = update.FindIndex(x => x == Key);
            var markerIndexes = new List<int>();
            foreach (var marker in Markers)
            {
                var index = update.FindIndex(x => x == marker);
                if (index != -1)
                {
                    markerIndexes.Add(index);
                }

            }

            return !markerIndexes.Any(mi => mi < keyIndex);
        }

        public string ToString()
        {
            return $"{Key}|{string.Join(",", Markers)}";
        }
    }
}
