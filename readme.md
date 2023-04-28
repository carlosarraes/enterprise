# Endpoints da Aplicação

Esse CRUD foi construída com .NET e Entity Framework, fornecendo uma plataforma para gerenciar informações de empresas, departamentos, funcionários e tarefas. Possibilita obter detalhes, criar novos registros e gerenciar status. O Entity Framework garante persistência de dados e gerenciamento de relacionamentos.

A aplicação foi criada como imagem Docker e implantada no Google Cloud Run.

App: [Swagger](https://netent-4wgfen3n5q-rj.a.run.app/swagger/index.html)

## Endpoints

### `GET /empresa/{id}`

Retorna uma lista completa sobre a empresa (nome, cnpj, funcionários [lista], departamento [lista])

<table>
<thead>
<tr>
<th>Response</th>
</tr>
</thead>
<tbody>
<tr>
<td>

```json
{
  "id": 0,
  "nome": "string",
  "cnpj": "string",
  "funcionarios": [
    {
      "funcionarioId": 0,
      "nome": "string",
      "departamentoNome": "string"
    }
  ],
  "departamentos": [
    {
      "departamentoId": 0,
      "nome": "string",
      "funcionarioCount": 0
    }
  ]
}
```

</td>
</tr>
</tbody>
</table>

### `POST /empresa/`

Cria uma empresa

<table>
<thead>
<tr>
<th>Body</th>
<th>Response</th>
</tr>
</thead>
<tbody>
<tr>
<td>

```json
{
  "nome": "Teste Company",
  "cnpj": "1234567890123"
}
```

</td>
<td>

```json
{
  "id": 0,
  "nome": "string",
  "cnpj": "string"
}
```

</td>
</tr>
</tbody>
</table>

### `GET /departamento/{id}`

Retorna informações do departamento (id, nome e quantidade de funcionários)

<table>
<thead>
<tr>
<th>Response</th>
</tr>
</thead>
<tbody>
<tr>
<td>

```json
{
  "departamentoId": 0,
  "nome": "string",
  "funcionarioCount": 0
}
```

</td>
</tr>
</tbody>
</table>

### `POST /departamento/`

Cria um departamento e o atribui a uma empresa

<table>
<thead>
<tr>
<th>Body</th>
<th>Response</th>
</tr>
</thead>
<tbody>
<tr>
<td>

```json
{
  "Nome": "Departamento de Serviços",
  "EmpresaId": 1
}
```

</td>
<td>

```json
{
  "departamentoId": 0,
  "nome": "string",
  "funcionarioCount": 0
}
```

</td>
</tr>
</tbody>
</table>

### `GET /funcionario/{id}`

Retorna dados de um funcionário, (id, nome, departamento)

<table>
<thead>
<tr>
<th>Response</th>
</tr>
</thead>
<tbody>
<tr>
<td>

```json
{
  "funcionarioId": 0,
  "nome": "string",
  "departamentoNome": "string"
}
```

</td>
</tr>
</tbody>
</table>

### `POST /funcionario/`

Cria um funcionário e o atribui a um departamento

<table>
<thead>
<tr>
<th>Body</th>
<th>Response</th>
</tr>
</thead>
<tbody>
<tr>
<td>

```json
{
  "nome": "Mayra Gumbol",
  "empresaId": 1,
  "departamentoId": 3
}
```

</td>
<td>

```json
{
  "funcionarioId": 0,
  "nome": "string",
  "departamentoNome": "string"
}
```

</td>
</tr>
</tbody>
</table>

### `GET /tarefa/{id}`

Retorna informações da tarefa (tarefaid, nome, descrição, status, funcionários (nomes))

<table>
<thead>
<tr>
<th>Response</th>
</tr>
</thead>
<tbody>
<tr>
<td>

```json
{
  "tarefaId": 0,
  "nome": "string",
  "descricao": "string",
  "status": true,
  "funcionarios": [
    {
      "nome": "string"
    }
  ]
}
```

</td>
</tr>
</tbody>
</table>

### `POST /tarefa/`

Cria uma tarefa

<table>
<thead>
<tr>
<th>Body</th>
<th>Response</th>
</tr>
</thead>
<tbody>
<tr>
<td>

```json
{
  "Nome": "Tarefa exemplo",
  "Descrição": "Descrição qualquer",
  "Status": false
}
```

</td>
<td>

```json
{
  "tarefaId": 0,
  "nome": "string",
  "descricao": "string",
  "status": true,
  "funcionarios": [
    {
      "nome": "string"
    }
  ]
}
```

</td>
</tr>
</tbody>
</table>

### `PATCH /tarefa/{id}`

Altera o status de uma Tarefa para verdadeiro

<table>
<thead>
<tr>
<th>Response</th>
</tr>
</thead>
<tbody>
<tr>
<td>

```json
{
  "tarefaId": 0,
  "nome": "string",
  "descricao": "string",
  "status": true,
  "funcionarios": [
    {
      "nome": "string"
    }
  ]
}
```

</td>
</tr>
</tbody>
</table>

### `GET /funcionariotarefa`

Retorna todas as tarefas com as pessoas que estão nessa tarefa - Lista com tarefaId, nome da tarefa, status, funcionários (lista)

<table>
<thead>
<tr>
<th>Response</th>
</tr>
</thead>
<tbody>
<tr>
<td>

```json
[
  {
    "tarefaId": 0,
    "nome": "string",
    "status": true,
    "funcionarioNomes": ["string"]
  }
]
```

</td>
</tr>
</tbody>
</table>

### `POST /funcionariotarefa`

Atribua uma tarefa a um funcionário

<table>
<thead>
<tr>
<th>Body</th>
<th>Response</th>
</tr>
</thead>
<tbody>
<tr>
<td>

```json
{
  "FuncionarioId": 4,
  "TarefaId": 2
}
```

</td>
<td>

```json
{
  "tarefaId": 0,
  "nome": "string",
  "status": true,
  "funcionarioNomes": ["string"]
}
```

</td>
</tr>
</tbody>
</table>
