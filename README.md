# BankerBot
¿Tenés problemas para administrar tus finanzas personales?, ¿llegás a fin de mes con poco dinero?, ¿querés ahorrar para un objetivo y no podés controlarlo?,  
Si alguna de estas preguntas la respondés con un sí, o si simplemente querés ser mas ordenado con tus finanzas, ***¡te invitamos a usar el Bankerbot!***.

## Propósito
Nuestro bot procura asistirte en la administración de tus finanzas personales de una manera cómoda y personalizable.  
    Para interactuar contigo, el BankerBot está configurado para funcionar mediante mensajes enviados en Telegram, aunque el código es fácilmente modificable y podés utilizarlo con **cualquier otro medio de comunicación**.<sup>1</sup>
  
## Funciones
**Banky**, *como nos gusta llamar a nuestro bot*, te permite realizar muchas tareas:
1. Registrar gastos.
2. Clasificar los gastos por su rubro.
3. Obtener resúmenes de gastos por rubros.
4. Establecer objetivos de ahorro, límites de gasto y fondos mínimos.
5. Activar alertas personalizables para cuando alcances tu ahorro marcado, superes el límite de gasto o estés por quedarte sin fondos.
6. Administrar tus métodos de pago, podrás agregar o quitar los medios que tengas.
7. Podrás utilizar más de una moneda.
8. Obtener cotizaciones actualizadas al momento de una moneda.
9. Hacer conversiones de moneda con sus cotizaciones actualizadas.
10. Saber los movimientos de los métodos de pago.
11. Agregar ingresos, gastos o transferencias internas entre tus medios de pago.
12. Si utilizas tarjeta de crédito, podrás ver cuanto tendrás que pagar al cierre de la misma.
13. Obtener reportes al día de la fecha de los ahorros que tenés en tus cuentas.
14. Obtener reportes al día de los gastos que llevas y en que rubros.



## Bibliografía Consultada
>  
>***Learning is a treasure that will follow its owner everywhere.***
>  
    University of Texas at San Antonio. UML. (http://www.cs.utsa.edu/~cs3443/uml/uml.html)

    Rumyancev, P. (2020). UML Class Diagram Arrows Guide. Medium (https://medium.com/the-innovation/uml-class-diagram-arrows-guide-37e4b1bb11e)
     
    Holub, A. (2017). UML Quick Reference. (https://holub.com/uml)

    Nyakundi, H. (2021). How to write a good README file for your Github Project. freeCodeCamp. (https://www.freecodecamp.org/news/how-to-write-a-good-readme-file/)

    Maurandi A., Palazón JA. (2013). markdown: guía breve y detallada. (http://fobos.inf.um.es/R/taller5j/30-markdown/guiabreveW.pdf)

    Refactoring.Guru. (2014-2021). Design Patterns (https://refactoring.guru/design-patterns)   

    The NUnit Project. (2018). NUnit Documentation Site (https://docs.nunit.org/index.html)

## Como utilizar el bot
Nuestro bot se encuentra en Fase II, esto quiere decir que está su core terminado pero no el relacionamiento con gateway de mensajes o servicios externos.     
Debido a esto sólo podrás utilizarlo solo por consola.    
Una vez que nuestro bot se encuentre desarrollado por completo, encontrarás aquí la guia paso a paso para utilizarlo y videos instructivos.


## Desafíos y Reflexiones
### Repasar UML
Nos pareció que, durante el curso, aprendimos UML pero no llegamos a comprender las formas de relacionamiento entre las clases, es por eso que consultamos distintas fuentes en línea para terminar de comprender los conceptos de representación gráfica de las relaciones entre clases.    
Nos ayudo mucho utilizar referencias rapidas como esta:
   ![Figura 1](Adjuntos/RecursosReadme/UMLcheatsheet.gif?raw=true "Figura 1 - UML Cheatsheet")    
               *Figura 1 - UML Cheatsheet*

### Comprensión de la tarea a realizar
En primera instancia, el bot parecía fácil de realizar, esto se debía a que no comprendíamos la extensión de tareas a realizar.  
  Para esto, investigamos sobre las distintas funciones que debería tener un sistema de finanzas personales, accediendo a varios ejemplos para recabar ideas.   
  Una vez realizado esto, pudimos desarrollar una serie de funciones, casos y necesidades que puede tener el usuario para que el uso de nuestro bot sea satisfactorio y cumpla con las expectativas.

### Implementación de Tests
Sin duda que los Test se vuelven una herramienta sumamente necesaria, y es que no hay código que no se vea alterado después de la implementación de estos.  
  El nuestro no fue un caso ajeno, la batería de test realizadas nos hizo darnos cuenta que existían falencias en nuestro código, fallos en su lógica o que podíamos implementar un código más limpio.  
  Nos dedicamos arduamente a esta tarea para poder garantizar que nuestro programa funciona, que se cumple lo que se propuso y que, al final del día, nuestro esfuerzo está bien dirigido y el resultado es satisfactorio.

### Creación de la User Interface
Un desafío que encontramos y nos ayudó mucho a reflexionar fue la tarea de crear la User Interace.   
La importancia recae en que la interfase es la espina dorsal de nuestro bot, ya que es el catalizador de todo el programa, es quien envía los mensajes a las distintas clases para realizar las tareas que queremos ejecutar como usuario.   
La conjunción de tareas genera una gran complejidad a la hora de hacer estas comunicaciones respetando los patrones y principios aprendidos.    
A su vez, la imagen que da la interfase de usuario es la cara de nuestro bot con el cliente, podemos desarrollar el mejor código que, si no le damos una buena experiencia al consumidor, no estaríamos cumpliendo nuestro objetivo completamente.

### Resolución de conflictos
En el equipo no todos teníamos experiencias con Github.    
Uno de los desafíos que nos planteó fue la resolución de conflictos, lo cual ocurría en oportunidades por la realidad del trabajo colaborativo. Una de los principios que tomamos como equipo fue *todos colaboramos en todo*.    
El resultado, un código más limpio y ordenado pero varios conflictos en los merges de ramas.    
Esto nos permitió amigarnos más con la plataforma y aprender a resolverlos de manera perfecta y sin contratiempos.    
Nos pareció algo a resaltar porque entendimos que el pilar fundamental de la programación es el trabajo en equipo (*que es la realidad del mercado laboral*), y un equipo bien aceitado genera una sinergia que lo hace llegar más lejos.

### Refactoring
El hecho de haber escrito un buen nivel y cantidad de tests nos permitió hacer refactoring de nuestro código en múltiples ocasiones, especialmente, posterior a la entrega de la Fase II y tras una revisión por parte de los profesores, se encontraron múltiples errores en el diseño del Bot. 
Estos errores al nivel de patrones y principios generaban que nuestro código presentara un alto acoplamiento en sus clases, donde clases de bajo nivel dependían de clases de bajo nivel, dándole demasiada rigidez y fragilidad. 
La tarea fue aplicar una serie de patrones y principios (Creator, Chain of Responsibility, DIP, entre otros), para mejorar la calidad de nuestro código y así tener un producto que cumpliera con OCP, que fuera robusto y con bajo acoplamiento. 
Gracias a los Test que habíamos hecho, sabíamos que podíamos generar un refactoring del código con la confianza de que nuestra resolución de problemas era la correcta. 
Pero eso no fue todo, la realidad de empezar a hacer este proceso nos permitió ir mejorando cada vez más el código, eliminando clases innecesarias, métodos demasiado rebuscados o dependencias de bajo nivel, lo cual nos dejó muy satisfecho con el resultado. 

### Integración de la API HTML
La posibilidad de interactuar con esta API fue una oportunidad muy valorada por nosotros, nos gustó el desafío de tener un módulo de código pronto y trabajar en la integración del mismo a nuestro programa. 
Nuestro objetivo con los reportes HTML era que los mismos se adaptaran al usuario, por lo tanto, debían tener métodos que generaran automáticamente el contenido de las filas y celdas acorde a la información del usuario. 
Para eso comenzamos diseñando una tabla en Word que se asemejara al resultado esperado, posterior a eso comenzamos a escribir el código que nos permitiera acercarnos a ese objetivo. 
Nuestro primer problema se dio cuando, dentro de la tabla y en la lista de filas, pretendimos agregar un método que recorriera la información y agregara filas y celdas acorde a los datos relevantes. Esto nos daba un error ya que no podíamos utilizar *foreach* dentro de la tabla. La solución la generamos al hacer toda la lista de filas fuera de la tabla, para luego solo agregarlas oportunamente a esta. 
Nuestro segundo problema se da cuando, al final de la tabla, queremos explicitar en una celda el total de la información (sean los saldos o los gastos), debido a la forma que teníamos implementada para obtener estos resultados, ninguno tenía como resultado un double o int. 
Para eso, en un principio agregamos dos largos métodos que hicieran esta tarea en el perfil del usuario, el problema al hacer esto era que íbamos en contra de *SRP* (porque le estábamos dando dos razones más de cambio al perfil de usuario) y con *DIP* (porque dependíamos de una clase de bajo nivel). 
Al observar esto, decidimos hacer un brainstorming para encontrar una manera de evitar esta complicación y tras reflexionar diversas maneras, apareció la solución la cual con tan solo un par de líneas de código dentro del foreach, sumaba los valores que iba obteniendo para cada celda, resultando en el total para agregar al footer.


### Implementación con Telegram
La implementación con la interface de Telegram se convirtió en nuestro desafío más grande, fue tal la magnitud de este desafío que lamentablemente no pudimos resolverlo a tiempo para la entrega, consideramos que era cuestión de tiempo para poder resolver este problema, continuar probando otras formas de lograr el funcionamiento fluido del trabajo. 
Nos deja acongojados en cierta manera porque creíamos que era posible lograrlo a tiempo, aunque estamos orgullosos de haber dado el cien por ciento de nuestro esfuerzo, con la satisfacción de que cumplimos en levantar un bot y que este interactúe con nuestro usuario, lamentamos que la interacción no fuese la esperada.  

### Gestión de Proyecto
La gestión del proyecto fue un desafío y nos dejó con un gran abanico de reflexiones. 
Entender que no siempre se van a dar las condiciones ideales para realizar el trabajo es prácticamente la realidad de la vida. 
En nuestro equipo, se dio la situación de que los tres integrantes trabajábamos 40 horas semanales o más en algunos casos y en horarios distintos, imposibilitando el trabajo en conjunto de lunes a viernes, esto hacía que el trabajo individual fuese clave para alcanzar las metas trazadas. 
Para eso, era importante realizar una correcta y clara delimitación de las áreas de responsabilidad y de los plazos de entrega de las funciones, de manera que cada integrante estuviese en conocimiento sobre que tenía que hacer y para cuando tenía que hacerlo. Así mismo, el código escrito por cada integrante debía ser chequeado por otro compañero del equipo para verificar que este cumpliera los patrones y principios, estuviese justificado correctamente y respaldado por los test necesarios para validar su funcionalidad. 
Esta situación propulsó la investigación individual, ya que cada uno debía instruirse en la solución de errores cuando se presentaban para poder continuar con su trabajo, ya que la espera para obtener la ayuda de otro compañero podía demorar el trabajo. Para estas consultas, cuando podían ser rápidas, nos enviábamos capturas o mensajes por WhatsApp para que otro nos respondiera desde su trabajo. Cuando eran demasiado complejas, utilizábamos el Discord del grupo para compartir pantalla y hacer la resolución en conjunto. 
Lamentablemente, un aspecto negativo de nuestra gestión fue no haber cumplido con el objetivo al cien por ciento, esto se debe a que, faltando dos semanas para la entrega, uno de los integrantes no aportó más al trabajo sin dar una explicación ni respuesta. El error recae en que no tomamos las medidas adecuadas en los tiempos correctos para poder obtener una respuesta acorde, esperando hasta último momento el aporte de este integrante. A raíz de eso, nuestra planificación se mantuvo como si el equipo fuera integrado por tres, cuando en la realidad, las últimas dos semanas terminamos dos compañeros directamente haciendo el trabajo. 

## Créditos
Este bot fue realizado por el equipo "Los Tres Mosqueteros" para la materia Programación 2 de la Universidad Católica del Uruguay "Damaso Antonio Larrañaga".  
Los tres mosqueteros está conformado por:
1. Matías Ferreira
2. Juan Andrés Leal
3. Sonia Olivera    

![Figura 2](Adjuntos/RecursosReadme/3Mosqueteros.jpg?raw=true "Figura 2 - Los tres mosqueteros")   

El product owner de este bot es:  
**Bruno Hiriart**   

## Medios de contacto
Puedes contactarnos a cualquier integrante del equipo para resolver tus dudas o problemas con la utilización de ***Banky***
1. Matías Ferreira - matias.ferreira@correo.ucu.edu.uy
2. Juan Andrés Leal - andres.leal@correo.ucu.edu.uy
3. Sonia Olivera - sonia.olivera@correo.ucu.edu.uy

---
<sup>1</sup>: Este código aplica el Principio Open Close Principle (OCP), el cual permite agregar nuevas funcionalidades haciendo cambios mínimos en el código. Procuramos aplicar este principio para integrar otros medios de comunicación.