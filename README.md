# 🦇 THE BATMAN - Console Adventure Game

## 📖 Opis projektu

**The Batman** to tekstowa gra przygodowa napisana w języku **C#** jako projekt zaliczeniowy.

Gracz wciela się w Batmana, którego zadaniem jest powstrzymanie największych przestępców Gotham City: Pingwina, Riddlera oraz Jokera. Każdy przeciwnik wymaga innego podejścia – od pościgów, przez zagadki logiczne, aż po rozbudowane walki z bossami.

Gra została napisana jako aplikacja konsolowa i wykorzystuje programowanie obiektowe.

---

# 🎮 Fabuła

W Gotham City pojawia się nowa substancja chemiczna **Smylex-X**, nad którą pracują Joker, Riddler oraz Pingwin.

Batman rozpoczyna śledztwo w Batcave.

Podczas gry gracz:

- ściga Pingwina ulicami Gotham,
- rozwiązuje zagadki Riddlera,
- odkrywa spisek dotyczący Smylex-X,
- odwiedza różne lokacje miasta,
- ulepsza wyposażenie Wayne Enterprises,
- walczy z Jokerem w Arkham Asylum.

Ostateczna walka odbywa się w dwóch etapach:

- Joker przed użyciem Smylex-X
- Joker po mutacji wywołanej Smylex-X

---

# 🌆 Lokacje

Gra zawiera między innymi:

- 🦇 Batcave
- 🏢 Wayne Tower
- 🚓 Police Station
- 🧩 Riddler Hideout
- 🐧 Iceberg Lounge
- 🌊 Canal Hideout
- 🃏 Arkham Asylum
- 🎰 Casino Gotham

---

# ⚔️ System walki

Gra posiada turowy system walki.

Podczas każdej tury Batman może:

- wykonać szybki atak,
- rzucić batarangiem,
- uleczyć się,
- użyć specjalnego gadżetu.

Boss Joker posiada własną sztuczną inteligencję:

- specjalne sztuczki,
- losowe komentarze,
- dwa etapy walki,
- mutację po użyciu Smylex-X.

---

# 🦇 Gadżety Batmana

Batman korzysta z wielu gadżetów:

- 🪃 Batarang
- 💨 Granat dymny
- ⚡ EMP Batarang
- 🪝 Hak z linką

Gadżety wpływają na przebieg obecnej oraz następnej tury walki.

---

# 🧩 Zagadki Riddlera

Aby schwytać Riddlera należy rozwiązać wszystkie zagadki bez popełnienia błędu.

Gra zawiera:

- Snake Puzzle
- Memory Bomb
- Sejf Riddlera

Pomyłka powoduje rozpoczęcie całego wyzwania od początku.

---

# 🏎️ Pościg za Pingwinem

Batman ściga Pingwina Batmobilem.

Jeżeli gracz przegra wyścig:

- Pingwin ucieka,
- odblokowuje się Canal Hideout,
- Batman musi odnaleźć nowe wskazówki prowadzące do jego kryjówki.

---

# 🏢 Wayne Tower

Wayne Enterprises pozwala rozwijać Batmana.

Za każdego schwytanego przestępcę gracz otrzymuje punkt ulepszeń.

Możliwe ulepszenia:

- zwiększenie siły ataku,
- zwiększenie obrony,
- zwiększenie limitu batarangów.

Wyświetlany jest również aktualny stan batarangów.

Przykład:

```
Batarangi: 6 / 9
```

---

# 🎰 Casino Gotham

Gra zawiera dwa minigry.

## 🎲 Ruletka

Gracz wybiera liczbę od **0 do 99**.

Jeżeli wylosowana liczba będzie identyczna:

➡️ Batman natychmiast wygrywa całą grę.

---

## 🃏 Blackjack

Gra przeciwko krupierowi.

Zasady:

- prawdziwe figury kart (J, Q, K, A),
- dynamiczny As (1 lub 11),
- krupier dobiera do 17 punktów,
- klasyczne zasady Blackjacka.

---

# 🏆 System postępu

Gra śledzi liczbę schwytanych przestępców.

Od liczby schwytanych przeciwników zależy:

- możliwość rozpoczęcia walki z Jokerem,
- dostęp do ulepszeń,
- rozwój fabuły.

---

# 💻 Technologie

Projekt został napisany w:

- C#
- .NET
- Programowanie obiektowe (OOP)

Wykorzystano między innymi:

- klasy
- dziedziczenie
- polimorfizm
- kolekcje
- metody statyczne
- losowość (Random)
- obsługę konsoli

---

# 📂 Struktura projektu

Przykładowe klasy:

```
Character.cs
Player.cs
Enemy.cs
BossEnemy.cs
CombatSystem.cs
Game.cs
Location.cs
RiddleChallenge.cs
Casino.cs
Card.cs
Effects.cs
HackSystem.cs
```

---

# 🎯 Cel gry

Pokonaj wszystkich przestępców Gotham.

✔ Schwytaj Pingwina

✔ Rozwiąż wszystkie zagadki Riddlera

✔ Odblokuj Arkham Asylum

✔ Pokonaj Jokera

✔ Powstrzymaj Smylex-X

✔ Ocal Gotham City

---

# 👨‍💻 Autor

Projekt wykonany jako gra konsolowa w języku **C#**.

