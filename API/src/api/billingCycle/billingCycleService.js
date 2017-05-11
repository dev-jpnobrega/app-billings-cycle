const BillingCycle = require('./billingCycle')
const errorHandler = require('../common/errorHandler')


BillingCycle.methods(['get', 'post', 'delete', 'put'])

// NEW: retorna o registro (PUT) atualizado 
// runValidators: Verifica as validações do schema
BillingCycle.updateOptions({new: true, runValidators: true})

// Adiciona o middles para esses methods
BillingCycle
    .after('post', errorHandler)
    .after('put', errorHandler)

// Novo method
// COUNT (router : BillingCycle/count (GET))
BillingCycle.route('count', (req, resp, next) => {
    BillingCycle.count((error, value) => {
        if (error) {
            res.status(500).json({errors: [error]})
        } else {
            resp.json({value})
        }
    })
})

// Pipeline para montar o summary
// SUMMARY (router : BillingCycle/summary (GET))
BillingCycle.route('summary', (req, resp, next) => {
    BillingCycle.aggregate({
        $project: {
            credit: {$sum: "$credits.value"},
            debit: {$sum: "$debits.value"}
        } //primeiro passo agrupagar os creditos e debitos de cada ciclo
    }, {
        $group: { 
            _id: null,
            credit: { $sum: "$credit" },
            debit: { $sum: "$debit" }
        } //segundo passo agrupando os totais de cada ciclo em um total geral        
    }, {
        $project: {_id: 0, credit: 1, debit: 1} //terceiro passo projetando os campos que vão ser a respsota
    }, (error, result) => { //callback de resposta depois dos passos
        if (error) {
            res.status(500).json({errors: [error]})
        } else {
            resp.json(result[0] || {credit: 0, debit: 0})
        }
    })
})

module.exports = BillingCycle
