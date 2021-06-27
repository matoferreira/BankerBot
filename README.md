# BankerBot
¿Tenés problemas para administrar tus finanzas personales?, ¿Llegás a fin de mes con poco dinero?, ¿querés ahorrar para un objetivo y no podés controlarlo?  
Si alguna de estas preguntas la respondés con un sí, o si simplemente querés ser mas ordenado con tus finanzas ***¡te invitamos a usar el Bankerbot!***.

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