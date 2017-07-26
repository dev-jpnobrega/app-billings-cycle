import React, { Component } from 'react'

import Grid from '../common/layout/grid'
import Rows from '../common/layout/row'
import ValueBox from '../common/widget/valueBox'

class Summary extends Component {
    render() {
        const { credit , debit } = this.props
        return (
            <Grid cols='12'>
                <fieldset>
                    <legend>Resumo</legend>
                    <Rows>
                        <ValueBox cols='12 4' 
                            color='green' icon='bank' 
                            value={'R$' + credit} text='Total de Créditos' />
                    
                        <ValueBox cols='12 4' 
                                color='red' icon='credit-card' 
                                value={'R$' + debit} text='Total de Débitos' />
                        
                        <ValueBox cols='12 4' 
                                color='blue' icon='money' 
                                value={'R$' + (credit-debit)} text='Valor Consolidado' />
                    </Rows>
                </fieldset>
            </Grid>
        )
    }
}

export default Summary
