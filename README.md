# CrashLab - **Intermittent Failure**


# 1. Visão Geral

O **CrashLab** é uma iniciativa educacional voltada para desenvolvedores em início de carreira, com o objetivo de simular cenários reais de manutenção de software em ambientes corporativos.

O **Challenge 1 — Intermittent Failure** introduz um problema clássico de produção:

> Um sistema aparentemente estável apresenta falhas ocasionais sob condições específicas, exigindo investigação técnica baseada em evidências.
> 

Diferente de exercícios acadêmicos, este desafio foi projetado para reproduzir **características reais de sistemas legados**, incluindo inconsistências de validação, baixa observabilidade e bugs não triviais.

---

# 2. Objetivo do Desafio

Capacitar o participante a:

- Diagnosticar falhas intermitentes
- Reproduzir erros a partir de cenários específicos
- Identificar causa raiz em código não ideal
- Corrigir o problema de forma segura
- Garantir ausência de regressão por meio de testes

---

# 3. Habilidade Principal Avaliada

### 🎯 Debugging baseado em evidência

O desafio foca exclusivamente em:

- Análise de fluxo de execução
- Investigação estruturada
- Uso de testes como ferramenta de diagnóstico
- Diferenciação entre sintoma e causa raiz

---

# 4. Escopo e Delimitações

Para garantir foco e efetividade pedagógica, o desafio **intencionalmente exclui**:

- Arquitetura distribuída
- Mensageria (ex: filas)
- Processamento assíncrono
- Banco de dados
- Refatorações estruturais extensas

> O objetivo é isolar a habilidade de debugging sem interferência de complexidade infraestrutural.
> 

---

# 5. Stack Tecnológica

O desafio utiliza uma stack moderna, porém simplificada:

```
- .NET 8
- ASP.NET Core (Minimal API)
- xUnit (testes automatizados)
- Swagger (exploração da API)
- ILogger (logging básico)
```

---

# 6. Arquitetura da Solução

A aplicação segue uma separação leve de responsabilidades, inspirada em sistemas reais:

```bash
/src
  CrashLab.Api          → entrada HTTP (Minimal API)
  CrashLab.Application  → lógica de negócio (onde o bug reside)
  CrashLab.Domain       → entidades

/tests
  CrashLab.Tests
```

---

## 📌 Fluxo de execução

```
HTTP Request
  → Endpoint Minimal API
    → DocumentProcessor
      → Normalize()
      → Validate()
      → Process()
```

---

# 7. Contexto do Sistema

## 📌 Domínio: Processamento de Documentos

A aplicação recebe um documento via requisição HTTP e realiza processamento síncrono.

---

## 📌 Endpoint principal

```
POST /documents/process
```

---

## 📌 Comportamento esperado

- Documentos válidos devem ser processados com sucesso

---

## 📌 Comportamento observado

- Em cenários específicos, ocorre falha em tempo de execução
- O erro não é evidente e depende de condições específicas do input

---

# 8. Natureza do Problema

## 🎯 Tipo de bug

- NullReferenceException
- Dependente de contexto (não ocorre sempre)
- Distribuído ao longo do fluxo

---

## 📌 Características do bug

- Não está localizado em um único ponto
- Não é detectado pelos testes existentes
- Depende de combinação de dados (ex: tipo do documento)

---

## 📌 Exemplo de cenário problemático

```json
{
  "type": "invoice",
  "customer": {
    "name": "Gabrielly"
  }
}
```

---

## 📌 Fator crítico

O erro ocorre apenas quando:

- `type = "invoice"`
- `customer.address` está ausente

---

# 9. Realismo (Simulação de Legado)

O desafio incorpora elementos comuns em sistemas reais:

- Validações incompletas
- Suposições implícitas no código
- Uso de strings ao invés de tipos fortes
- Logging insuficiente
- Inconsistência entre contrato e implementação

---

## 📌 Exemplo de log

```
[ERROR] Failed processing document type=invoice
```

> Informação insuficiente para diagnóstico direto.
> 

---

# 10. Estado Inicial dos Testes

- Existem testes automatizados ✔️
- Todos passam ✔️
- Cobertura incompleta ❌

---

## 📌 Limitação proposital

Os testes cobrem apenas o cenário ideal (happy path), não contemplando variações reais de dados.

---

# 11. Atividades Esperadas do Participante

O participante deverá:

### 1. Reproduzir o erro

- Utilizando Swagger ou testes

### 2. Criar um teste que falha

- Representando o cenário problemático

### 3. Identificar a causa raiz

- Através da análise do fluxo e código

### 4. Corrigir o problema

- Sem alterar comportamentos válidos

### 5. Garantir ausência de regressão

- Todos os testes devem passar

---

# 12. Critérios de Avaliação

A avaliação será conduzida via **Code Review**, simulando ambiente profissional.

---

## 📌 Critérios técnicos

- Reprodução correta do erro
- Qualidade do teste criado
- Identificação precisa da causa raiz
- Correção adequada e segura
- Preservação do comportamento existente

---

## 📌 Critérios qualitativos

- Clareza da solução
- Coerência na tomada de decisão
- Evitação de “quick fixes”
- Entendimento do fluxo completo

---

# 13. Entregáveis

O participante deve submeter:

```
- Código com correção implementada
- Teste automatizado cobrindo o cenário
- Explicação da causa raiz (README ou comentário técnico)
```

---

# 14. Diferenciais do Desafio

Este desafio se destaca por:

- Simular condições reais de sistemas legados
- Focar em uma habilidade crítica e pouco treinada
- Utilizar code review como mecanismo de avaliação
- Evitar complexidade artificial (infraestrutura)

---

# 15. Nível de Dificuldade

| Dimensão | Nível |
| --- | --- |
| Infraestrutura | Baixo |
| Implementação | Médio |
| Raciocínio | Alto |

---

# 16. Resultado Esperado

Ao final do desafio, o participante deverá demonstrar:

- Capacidade de investigação técnica estruturada
- Uso eficaz de testes para diagnóstico
- Entendimento de causa raiz
- Correção segura em código legado

---

# 17. Posicionamento no Programa

Este é o **primeiro desafio do CrashLab**, com foco em:

> Fundamentos de debugging antes da introdução de complexidade arquitetural
> 

---

## 📌 Evolução futura

Desafios posteriores poderão incluir:

- Concorrência
- Processamento assíncrono
- Integrações externas
- Arquiteturas distribuídas

---

# 18. Conclusão

O **Challenge 1 — Intermittent Failure** estabelece a base do programa CrashLab ao desenvolver uma competência essencial para atuação profissional:

> A capacidade de investigar, compreender e corrigir problemas reais em sistemas imperfeitos.
> 

A proposta equilibra realismo e controle, oferecendo um ambiente seguro para desenvolvimento de habilidades críticas amplamente exigidas no mercado
