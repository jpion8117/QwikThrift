using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QwikThrift.Migrations
{
    public partial class saltedPasswordHashes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasswordSalt",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 4,
                column: "ListingTime",
                value: new DateTime(2023, 10, 9, 19, 23, 55, 320, DateTimeKind.Local).AddTicks(8332));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "ぬ녆쓳虄긲췔硬궈䥎氩䙆鐾䥚㘻몶㘨ᑇꇺ밗‬ሑ須⫶䕃靏瓦욾뮅꣐쿂", "y/a7L$Z}k{X[+_8iZsPSQO4;a-&GnWb,+{^xw1#)&Ui8K9ZklSPRMy57<U&)LbFqIEJ|M>A5V</e5q==QVFT`fym2$sok)DYP56k+@0K|XDrrJ]xo4hKgNo|x+*`[G@<]PedP|q[[GNXu6jlF;o[,^HrU[325IuF3s}wrjJ&7SHI/IOoMWb97-rxCjz.+S^@%c|ov(fCZu@VvCTv`|?V2}0#K%dJD&6>@8#R4D5Att-KLmF&LaQwj@Ng2yC.3Q7T" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "卲ੇ᝭袴厉ﬅ⏫돺溺୥腢ꏥꥯ丛羇𥳐⹀㴸蜨笆蒇볘먯䷍�⯕짳뻞곧䭃⟊", "3)Y;;z&w:%1+ej[ryQ<#M}PO))[x<p@^:b:Rh/;wL_M'S3&ehys8}vsWUF:oQ'Lc`jD[|Ll/NR\\,(F]>gxcQ6FABu8y8q/\\El\\ic_3%{AL319ce6V+-_FfpvT0I4fS#XV1EkApApSP@`NN^29=}wXV(m}1h7F#DH>Q6e}c+vvo5?TbHWam5dr_@JsQ2rfd^\\]au]<bwl?k5/75p0XgoZ9\\ses,]4,hrsP`,HRgP.hShw'Pn[-<l`R,[36Z5Bu=e\\" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "얫Ꞿ�㻔Ҹ㼗ᖣ鵍뗵布㜄䟠랢册ꆔ颋盧큓ͺ糶彄궘ﵧ঎⁾쀢捶루ꡔ", "MKT#O[0#suBI1KN:BkduxR/sBTQ)xg#J9<@pcwSk.YcSJ/i|\\<rC}A_H_cRIswY|\\)?w3OiNt(lV[:C@$.o@Pno?|$OKVcYQ+3qt=G]4W$KUnzp6AfHj>?1zg%82FSi?#@g+z$*Z%_f7g,Wvbc=cF%$x+%W2tv&&rpEi>tFd^xUTAB={SQHr{owm58LH'\\>P-C,rL?%vt<[:D-vrZp5WGu:$d]^}v*_M5ZcQ'C1|^T8MN=s5Jth:SlF1HC-Sn)U)" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "憢⢯钗郩ꍺᛪ忄졒鷁ॢ웵驑私鶂߭溼蘮龱쎶湸蜐ꪌ䰽�鋚巅ᘘ㻵맀", "-2><d:vu0es:oF{$@lGz{b1Xs@Pl_Jg,aR\\rziv/RE=q*HFUt}KC^QSk&SRJ.3j478BMfDy/8qV(e^WiI//Ma2Gw\\;&P:Ib_cm8&#nhu,'K7|'S:$A+8_#LqX&Q&,k03D_e^1B%><dPsmNCKNO`v%%`I8UD(rU]}a'xN[zp//<S{K1&IR&ZP)F`-+*6(porA#X3SI>yU.3*FYD#zgkN6Bih:fH70Z_9]vey(EVr[OvZ#{)3{QU$.j`:z<0jtw2&Z" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "臨꼅㪜쉊ꏫ�닾쌝�￯줠傼釦魒嶳竻跡遛곴⬊⮬�ꊺᲡ网廳浥뼇闺㖊", "=2v31(@T(0<B:p<E#xaCM|SI;CBNZafE_`r\\<BTqI5C=1_3[y42MK9fB#*gt#:`S8N9U/-Kx',WN-{SoZtlTHq)lZd{`d8[eI>Q`9y.W@5E&bE.Xu-<}mrW6ZLxvu#3bWTPBkaE/G10wE&qB;L(`Yf`@}-$T|Sg4j9<\\UXi*]AD\\TKWUyflIkRB%+*g?vn91@z)z](c:NF1F\\+VDtfZ:m0g'Sd;xO|yK<e]/={%](B%zkaW+z;,clQ\\bqa,?)|:7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 4,
                column: "ListingTime",
                value: new DateTime(2023, 10, 5, 16, 24, 2, 967, DateTimeKind.Local).AddTicks(2393));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "PasswordHash",
                value: "굖鋠㤰䇸ꅄᒑⓈꊲ⚓�］꺑᝚ꋴ띎ऎ쥸퓋⿉ʭ욪빖�牔⾉떛");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "PasswordHash",
                value: "弼薉뱦烙Њ噲䵦ഛᛪ䫽拐誆ײ脻♹她冀侗願뼞伝꣺빙﯌㝵沈覅�");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "PasswordHash",
                value: "튛㖧ட㷛㓬邯∤쟿낍�⠴꬯흡勵詫ꎠ毃띩ꡅ蒪ᥕŇ竫ၗ文惲䶺蓷対颱㾾");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "PasswordHash",
                value: "巰锳䈨頴上跒鹓ㄣ⼦๲懺蝘茓ꝿ焗ᩝ᠇摝췭鿄돜䳝ᔃ⭊�靛腇簲꽀");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "PasswordHash",
                value: "룐蝹온魎绸懪吇摧峒�钿诼❆볫忳郘뮅配㧈쥐໼⏜�翔輇陋틤끆");
        }
    }
}
