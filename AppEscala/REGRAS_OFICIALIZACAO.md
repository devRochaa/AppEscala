# Regras de bloqueio da oficializacao

Este documento registra as regras atuais usadas para permitir ou bloquear a oficializacao da escala.

## Linhas consideradas

Somente linhas consideradas na oficializacao entram nas validacoes abaixo.

Uma linha pode ser desconsiderada pelo usuario no preview da escala usando o botao direito sobre a linha e a opcao `Desconsiderar na oficializacao`.

Quando uma linha esta desconsiderada:

- continua aparecendo normalmente no preview da escala;
- continua aparecendo normalmente no PDF;
- continua valendo visualmente como parte da escala;
- nao soma missa servida para os acolitos na oficializacao;
- nao bloqueia a oficializacao por problemas de horario, vinculo ou ausencia de acolitos.

## Regras que bloqueiam a oficializacao

### 1. Nenhuma linha valida para oficializar

A oficializacao e bloqueada quando nao existe nenhuma linha considerada com acolitos vinculados.

Isso pode acontecer quando:

- a escala esta vazia;
- todas as linhas foram desconsideradas;
- nenhuma linha considerada tem acolitos vinculados ao cadastro.

Mensagem atual:

```text
Nao ha acolitos vinculados para oficializar.
```

ou, quando nao ha nenhuma missa coletada para soma:

```text
Gere a escala antes de oficializar.
```

### 2. Horario invalido

Se uma linha considerada tiver horario preenchido, ele precisa estar em um formato aceito pelo sistema.

Exemplos aceitos:

- `00:00`
- `7hs`

Mensagem atual:

```text
A linha X tem horario invalido. Use o formato 00:00 ou 7hs.
```

### 3. Acolitos preenchidos sem vinculo com o cadastro

A oficializacao e bloqueada quando a coluna `ACOLITOS` tem texto, mas a linha nao tem vinculo interno com os IDs dos acolitos cadastrados.

Isso pode acontecer quando:

- a escala foi importada de PDF;
- nomes foram editados manualmente;
- algum nome nao foi reconhecido no cadastro;
- o JSON importado aponta para acolitos que nao existem mais.

Mensagem atual:

```text
Esta linha tem acolitos sem vinculo com o cadastro. De dois cliques na coluna ACOLITOS e selecione os acolitos antes de oficializar.
```

### 4. Linha considerada sem acolitos vinculados

A oficializacao e bloqueada quando uma linha considerada tem dados de escala, mas nao possui acolitos vinculados para receber a contagem.

Mensagem atual:

```text
Esta linha nao tem acolitos vinculados para oficializar.
```

## Efeito da oficializacao

Ao oficializar:

- o sistema soma missa servida apenas para os acolitos das linhas consideradas;
- linhas desconsideradas nao somam missa servida;
- as missas vinculadas a escala sao inativadas.

