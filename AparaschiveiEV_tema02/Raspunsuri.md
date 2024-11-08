1. **Viewport** este o regiune de formă dreptunghiulară a ecranului unde sunt afișate elementele grafice într-o aplicație. În contextul OpenGL, viewport-ul este zona unde se realizează desenarea. Prin viewport, utilizatorul vede conținutul, iar modificarea acestuia influențează modul în care este proiectat conținutul.

2. **Cadru (Frame)** reprezintă o singură actualizare completă a graficii afișate, iar rata de cadre indică frecvența cu care OpenGL redă aceste cadre. Cu cât *frames per second* (FPS) este mai mare, animația va fi mai fluidă.

3. **Metoda OnUpdateFrame()** este rulată în bucla principală a aplicației, înainte de fiecare cadru randat. Această metodă se ocupă cu actualizarea logicii aplicației, cum ar fi pozițiile obiectelor, și este apelată la fiecare iterație a buclei de randare.

4. **Modul imediat de randare** este o metodă care nu mai este atât de folosită și presupune ca fiecare primitiv grafic este desenat imediat în funcția de redare, astfel comenzile de randare sunt trimise direct la GPU. Astfel, se produce un trafic de date mare, deoarece informațiile despre geometria formelor sunt mereu retrimise.

5. **OpenGL 3.2** permite modul imediat, dar acesta nu este recomandat în dezvoltarea modernă, deoarece există tehnici mai bune, cum ar fi utilizarea de shadere și bufferi.

6. **Metoda OnRenderFrame()** este apelată în fiecare cadru al buclei de redare a aplicației OpenGL. Aceasta se ocupă în principal cu randarea graficii pe ecran și este esențială pentru afișarea conținutului vizual al aplicației.

7. **Metoda OnResize()** asigură configurarea corectă a ferestrei, în special atunci când dimensiunea ferestrei se modifică. De asemenea, atunci când această metodă este executată, se actualizează și dimensiunile viewport-ului pentru a se randa corect grafica.

8. **CreatePerspectiveFieldOfView()** are următorii parametrii:
   - **FOV**: de tip `float`, care reprezintă unghiul de vizualizare vertical al camerei, măsurat în grade.
   - **aspectRatio**: de tip `float`, este raportul dintre lățimea și înălțimea ferestrei.
   - **nearPlane**: de tip `float`, distanța minimă de vizualizare; obiectele mai apropiate de cameră decât acest parametru nu vor fi randate.
   - **farPlane**: similar cu `nearPlane`, doar că obiectele mai îndepărtate decât acest parametru nu vor fi randate.