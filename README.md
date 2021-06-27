# BankerBot
¿Tenés problemas para administrar tus finanzas personales?, ¿Llegás a fin de mes con poco dinero?, ¿querés ahorrar para un objetivo y no podés controlarlo?  
Si alguna de estas preguntas la respondés con un sí, o si simplemente querés ser mas ordenado con tu dinero ***¡te invitamos a usar el Bankerbot!***.

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
    University of Texas at San Antonio. UML. (http://www.cs.utsa.edu/~cs3443/uml/uml.html)

    Rumyancev, P. (2020). UML Class Diagram Arrows Guide. Medium (https://medium.com/the-innovation/uml-class-diagram-arrows-guide-37e4b1bb11e)
     
    Holub, A. (2017). UML Quick Reference. (https://holub.com/uml/)

    Nyakundi, H. (2021). How to write a good README file for your Github Project. freeCodeCamp. (https://www.freecodecamp.org/news/how-to-write-a-good-readme-file/)

    Maurandi A., Palazón JA. (2013). markdown: guía breve y detallada. (http://fobos.inf.um.es/R/taller5j/30-markdown/guiabreveW.pdf)

    Refactoring.Guru. (2014-2021). Design Patterns (https://refactoring.guru/design-patterns)

## Desafíos y Reflexiones
### Repasar UML
Nos pareció que, durante el curso, aprendimos UML pero no llegamos a comprender las formas de relacionamiento entre las clases, es por eso que consultamos distintas fuentes en línea para terminar de comprender los conceptos de representación gráfica de las relaciones entre clases.
   Nos ayudo mucho utilizar referencias rapidas como esta:
   ![Figura 1](Adjuntos/RecursosReadme/UMLcheatsheet.gif?raw=true "Title")

### Comprensión de la tarea a realizar
En primera instancia, el bot parecía fácil de realizar, esto se debía a que no comprendíamos la extensión de tareas a realizar.
Para esto, investigamos sobre las distintas funciones que debería tener un sistema de finanzas personales, accediendo a varios ejemplos para recabar ideas.
Una vez realizado esto, pudimos desarrollar una serie de funciones, casos y necesidades que puede tener el usuario para que el uso de nuestro bot sea satisfactorio y cumpla con las expectativas.

### Implementación de Tests
Sin duda que los Test se vuelven una herramienta sumamente necesaria, y es que no hay código que no se vea alterado después de la implementación de estos.
    El nuestro no fue un caso ajeno, la batería de test realizadas nos hizo darnos cuenta que existían falencias en nuestro código, fallos en su lógica o que podíamos implementar un código más limpio.
    Nos dedicamos arduamente a esta tarea para poder garantizar que nuestro programa funciona, que se cumple lo que se propuso y que, al final del día, nuestro esfuerzo está bien dirigido y el resultado es satisfactorio.

---
<sup>1</sup>: Este código aplica el Principio Open Close Principle (OCP), el cual permite agregar nuevas funcionalidades haciendo cambios mínimos en el código. Procuramos aplicar este principio para integrar otros medios de comunicación.