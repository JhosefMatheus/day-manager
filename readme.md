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
      <td>Constraints</td>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>id</td>
      <td>int</td>
      <td>not null</td>
      <td>primary key</td>
    </tr>
    <tr>
      <td>name</td>
      <td>texto</td>
      <td>not null</td>
      <td></td>
    </tr>
    <tr>
      <td>login</td>
      <td>texto</td>
      <td>not null</td>
      <td>unique</td>
    </tr>
    <tr>
      <td>password</td>
      <td>texto</td>
      <td>not null</td>
      <td></td>
    </tr>
    <tr>
      <td>created_at</td>
      <td>datetime</td>
      <td>not null</td>
      <td></td>
    </tr>
    <tr>
      <td>updated_at</td>
      <td>datetime</td>
      <td>null</td>
      <td></td>
    </tr>
    <tr>
      <td>deleted_at</td>
      <td>datetime</td>
      <td>null</td>
      <td></td>
    </tr>
  </tbody>
</table>

<h2>Tarefa (task)</h2>

<p>Você verá que a tarefa possui um campo referenciando um id de um tipo de tarefa. Para mais informações sobre essa tabela procure por essa tabela.</p>

<table>
  <thead>
    <tr>
      <td>Coluna</td>
      <td>Tipo</td>
      <td>Nula</td>
      <td>Constraints</td>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>id</td>
      <td>int</td>
      <td>not null</td>
      <td>primary key</td>
    </tr>
    <tr>
      <td>user_id</td>
      <td>int</td>
      <td>not null</td>
      <td>foreign key refereces user.id</td>
    </tr>
    <tr>
      <td>task_type_id</td>
      <td>int</td>
      <td>not null</td>
      <td>foreign key references task_type.id</td>
    </tr>
    <tr>
      <td>name</td>
      <td>varchar</td>
      <td>not null</td>
      <td></td>
    </tr>
    <tr>
      <td>description</td>
      <td>varchar</td>
      <td>null</td>
      <td></td>
    </tr>
    <tr>
      <td>done</td>
      <td>boolean</td>
      <td>not null</td>
      <td></td>
    </tr>
    <tr>
      <td>created_at</td>
      <td>datetime</td>
      <td>not null</td>
      <td></td>
    </tr>
    <tr>
      <td>updated_at</td>
      <td>datetime</td>
      <td>null</td>
      <td></td>
    </tr>
  </tbody>
</table>

<p>Essa tabela possui constraint única composta com as seguintes colunas:</p>

<ul>
  <li>user_id;</li>
  <li>task_type_id;</li>
  <li>name;</li>
</ul>

<h3>Tipo da tarefa (task_type)</h3>

<p>Esa tabela é responsável por gerenciar os tipos de tarefas que teremos no sistema. Os tipos serão:</p>

<ul>
  <li>Diária;</li>
  <li>Dia específico;</li>
</ul>

<table>
  <thead>
    <tr>
      <td>Coluna</td>
      <td>Tipo</td>
      <td>Nula</td>
      <td>Constraints</td>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>id</td>
      <td>int</td>
      <td>not null</td>
      <td>primary key</td>
    </tr>
    <tr>
      <td>name</td>
      <td>varchar</td>
      <td>not null</td>
      <td>unique</td>
    </tr>
  </tbody>
</table>

<h3>Tarefa Dia (task_day)</h3>

<p>Essa tabela tem o objetivo de organizar todas as tarefas que são do tipo de tarefas diárias relacionando uma tarefa com seu dia.</p>

<table>
  <thead>
    <tr>
      <td>Coluna</td>
      <td>Tipo</td>
      <td>Nulo</td>
      <td>Constraints</td>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>id</td>
      <td>int</td>
      <td>not null</td>
      <td>primary key</td>
    </tr>
    <tr>
      <td>task_id</td>
      <td>int</td>
      <td>not null</td>
      <td>foreign key references task.id</td>
    </tr>
    <tr>
      <td>day</td>
      <td>int</td>
      <td>not null</td>
      <td></td>
    </tr>
  </tbody>
</table>

<p>Essa tabela possui uma constraint composta nas seguintes colunas:</p>

<ul>
  <li>task_id;</li>
  <li>day;</li>
</ul>

<p>Vale ressaltar que o campo day só poderá ser preenchido com valores númericos inteiros que estejam dentro do intervalo fechado [0, 6]</p>

<h3>Tarefa Dia Espicífico (task_specific_day)</h3>

<p>Essa tabela tem o objetivo de organizar todas as tarefas cujo tipo é de tarefa de dia específico.</p>

<table>
  <thead>
    <tr>
      <td>Coluna</td>
      <td>Tipo</td>
      <td>Nulo</td>
      <td>Constraints</td>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>id</td>
      <td>int</td>
      <td>not null</td>
      <td>primary key</td>
    </tr>
    <tr>
      <td>task_id</td>
      <td>int</td>
      <td>not null</td>
      <td>foreign key references task.id</td>
    </tr>
    <tr>
      <td>day</td>
      <td>date</td>
      <td>not null</td>
      <td></td>
    </tr>
  </tbody>
</table>

<p>Essa tabela possui uma constraint de unicidade composta nas seguintes colunas:</p>

<ul>
  <li>task_id;</li>
  <li>day;</li>
</ul>