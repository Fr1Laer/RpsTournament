# RpsTournament (Kivi-Paber-Käärid Turniir)

Lihtne C#- ja WPF-põhine rakendus, mis realiseerib mängu „Kivi, käärid, paber” 5-voorulise turniiri vormis

---

## Rakenduse kirjeldus

- **Arhitektuuri jaotus:** Mänguloogika on paigutatud klasside teeki (Core) ja kasutajaliides WPF-rakendusse (`WpfApp`)
- **Andmete valideerimine:** Mängija nime kontrollimine (pikkus 2–30 tähemärki) ja kohustuslik käigu valik
- **Turniiri piirang:** Turniir lõpeb automaatselt pärast 5. vooru, mil juhtimine blokeeritakse
- **Võitja kindlaksmääramine:** Punktide automaatne arvutamine ja turniiri lõpptulemuse väljatoomine, arvestades viiki ja mängija nime
- **Lokaliseerimine ja ressursid:** Kõik kasutajate sõnumid salvestatakse ressursifaili `Resources.resx`

---

## Kuidas mängida
- Sisesta mängija nimi (2–30 tähemärki)

- Vali oma käik rippmenüüst (Rock, Paper või Scissors)

- Vajuta nuppu "Mängi voor"

- Pärast 5 vooru ilmub staatusplokki turniiri lõpptulemus

- Uue mängu alustamiseks tuleb vajutada nuppu „Uus turniir“ ja tegevus kinnitada

---

## Vea näited

Viga "**Palun vali käik enne mängimist!**":

<img width="582" height="440" alt="Знімок екрана 2026-09-19 145349" src="https://github.com/user-attachments/assets/82227172-50aa-420e-b203-0e11b7245c3a" />

Viga "**Nimi peab olema 2–30 märgiga!**":

<img width="585" height="441" alt="image" src="https://github.com/user-attachments/assets/e8941969-a94a-4f25-935d-80c378821832" />

---
## Näide turniiri lõppemisest

Kasutaja võit:

<img width="584" height="438" alt="Знімок екрана 2026-09-19 152201" src="https://github.com/user-attachments/assets/7040b77a-1a24-4eba-a5ea-f48fc0b2b747" />

Arvuti võit:

<img width="586" height="438" alt="Знімок екрана 2026-09-19 152131" src="https://github.com/user-attachments/assets/2d5dce6b-71ee-486a-995f-30786c642225" />
