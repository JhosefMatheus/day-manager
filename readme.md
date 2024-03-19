<h1>Introdução</h1>

<p>Este projeto foi criado com o objetivo de organizar minhas tarefas diárias.</p>

<p>Eu organizava minhas tarefas diárias em um caderno, porém começou a ficar cansativo todo dia antes de dormir ou depois de acordar colocar cada coisa que eu tinha que fazer no dia.</p>

<h1>Organização do projeto</h1>

<p>O projeto vai ser organizado da seguinte forma:</p>

<ul>
  <li>
    <p>Frontend:</p>
    <ul>
      <li>Web (React);</li>
      <li>Mobile (Flutter);</li>
    </ul>
  </li>
  <li>Backend (.NET);</li>
</ul>

<p>Eu decidi estruturar o projeto dessa forma pelas seguintes razões:</p>

<ol>
  <li>
    <p>Centralização:</p>
    <p>Eu não quero depender de um único dispositivo ou ambiente para poder gerenciar minhas tarefas, então decidi que elas ficarão guardadas em um local na nuvem (por isso o backend) asim eu não preciso me preocupar caso eu desinstale ou qualquer outra eventualidade.</p>
  </li>
  <li>
    <p>Conhecimento:</p>
    <p>Eu quero manter meu conhecimento sempre "fresco", por isso decidi fazer em dois ambientes diferentes, web (react) e mobile (flutter).</p>
  </li>
  <li>
    <p>Estabilidade:</p>
    <p>Eu já tentei fazer esse projeto outras vezes, e utilizei o NestJS no backend, porém não foi muito do meu agrado, então decidi optar por uma linguagem que está mais consolidade e tem conceitos fortes nos paradigmas de orientação a objeto, pois isso promove maior organização para o projeto.</p>
  </li>
</ol>

<h1>Banco de dados</h1>

<h2>Usuário (user)</h2>

<p>Eu não planejo que esse sistema seja utilizado por milhares de pessoas, na verdade eu planejo que o sistema seja utilizado apenas por mim, porém, apenas por questões de aprendizado, vou considerar que o sistema vai ser utilizado por vários usuários, portanto, a definição da tabela do usuário vai ser feita para tal.</p>

<table>
  <thead>
    <tr>
      <td>Coluna</td>
      <td>Tipo</td>
      <td>Nula</td>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>name</td>
      <td>texto</td>
      <td>not null</td>
    </tr>
    <tr>
      <td>login</td>
      <td>texto</td>
      <td>not null</td>
    </tr>
    <tr>
      <td>password</td>
      <td>texto</td>
      <td>not null</td>
    </tr>
    <tr>
      <td>created_at</td>
      <td>datetime</td>
      <td>not null</td>
    </tr>
    <tr>
      <td>updated_at</td>
      <td>datetime</td>
      <td>null</td>
    </tr>
    <tr>
      <td>deleted_at</td>
      <td>datetime</td>
      <td>null</td>
    </tr>
  </tbody>
</table>

<h2>Tarefa</h2>

<h3>Tipo da tarefa</h3>
