1. **Triunghiuri și benzi de triunghiuri**  
   Vertexurile trebuie desenate în sens anti-orar pentru a fi considerate fața din față. Pentru puncte și linii, ordinea nu contează.

2. **Anti-aliasing**  
   Anti-aliasing este o tehnică folosită pentru a netezi marginile zimțate ale obiectelor pe ecran. Funcționează prin estomparea treptată a marginilor, adăugând pixeli de tranziție între obiect și fundal, astfel încât liniile și contururile să pară mai fluide și mai puțin "dințate".

3. **GL.LineWidth și GL.PointSize**  
   - `GL.LineWidth(float)` setează grosimea liniilor.  
   - `GL.PointSize(float)` setează dimensiunea punctelor.  
   Ambele comenzi funcționează în afara unui bloc `GL.Begin()...GL.End()`.

4. **Desenarea formei cu linii**  
   - `LineLoop`: Desenează linii între fiecare pereche de vertexuri și închide bucla între ultimul și primul vertex.  
   - `LineStrip`: Desenează linii între fiecare pereche succesivă de vertexuri, fără să închidă bucla.  
   - `TriangleFan`: Desenează triunghiuri folosind primul vertex ca centru și formează triunghiuri cu fiecare pereche de vertexuri succesive.  
   - `TriangleStrip`: Desenează triunghiuri succesive, fiecare triunghi având două vertexuri comune cu triunghiul anterior.

6. **Utilizarea culorilor în 3D**  
   Utilizarea culorilor diferite în desenarea obiectelor 3D este importantă pentru a evidenția detalii și pentru a crea efecte vizuale mai realiste. Avantajele includ:  
   - **Realism**: Culorile pot simula efectele de lumină și umbră pe suprafețele obiectelor.  
   - **Claritate**: Ajută la diferențierea diferitelor părți ale obiectului, îmbunătățind înțelegerea formei.  
   - **Estetică**: Crează un aspect vizual plăcut, mai atrăgător, prin variații de culoare sau gradienți.  
   - **Profunditate**: Oferă iluzia de adâncime și volum, prin contrastul dintre zonele de lumină și umbră.

7. **Gradient de culoare**  
   Un gradient de culoare reprezintă o tranziție lină între două sau mai multe culori, creând un efect de amestecare între acestea pe o suprafață.  
   În OpenGL, un gradient de culoare se obține folosind culori diferite pe diferite vârfuri ale unui obiect 3D (vertex colors). Când un obiect este desenat, OpenGL va interpolă culorile între vârfuri, creând efectul de gradient.

10. **Gradient de culoare în Line Strip și Triangle Strip**  
   Utilizarea unei culori diferite pentru fiecare vertex într-un line strip sau triangle strip creează un gradient de culoare între vertecși:  
   - **Line Strip**: Culoarea se interpolează între fiecare pereche de vertecși, formând un gradient pe linie.  
   - **Triangle Strip**: Culoarea se interpolează între vertecși, creând un gradient pe întreaga suprafață a triunghiului.
