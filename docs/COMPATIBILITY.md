# Compatibilidade

| Verificação | Estado |
| --- | --- |
| Build do mod principal no SPT 4.1.6 | Passou |
| Build do addon contra WeekendDrops 1.0.7 instalado | Passou |
| IDs e cobertura dos 30 bundles | Conferidos |
| 30 modelos no Unity Editor 2022.3.43f1 | Validação anterior do projeto |
| Startup dos dois pacotes separados | Pendente |
| Entrega e resgate no Weekend | Pendente |
| Host/cliente Fika | Pendente |

O addon depende de `CollectionService.LoadConfig` e do campo `_config` do Weekend. Uma mudança nessa API exige nova validação. As dependências de versão evitam tratá-lo como compatível automaticamente com futuras versões do Weekend.

Não distribui as DLLs de SPT, Weekend, Harmony ou Unity. O cliente precisa carregar os bundles corretos; uma compilação bem-sucedida no servidor não comprova renderização, sincronização ou funcionamento em raid.
