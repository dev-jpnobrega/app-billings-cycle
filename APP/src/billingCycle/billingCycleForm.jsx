import React, { Component } from 'react'
import { bindActionCreators } from 'redux'
import { connect } from 'react-redux'
import { reduxForm, Field, formValueSelector } from 'redux-form'
import { init } from './billingCycleAction'

import labelAndInput from '../common/form/labelAndInput'
import ItemList from './ItemList'
import Summary from './summary'

class BillingCycleForm extends Component {
    componentWillMount() {
        
    }

    calculateSummary() {
        const sum = (t, v) => t + v
        return {
            sumOfCredits: this.props.credits.map(c => + c.value || 0).reduce(sum),
            sumOfDebits: this.props.debits.map(d => + d.value || 0).reduce(sum)
        }
    }

    render() {
        const { handleSubmit, readOnly, credits, debits } = this.props
        const { sumOfCredits, sumOfDebits } = this.calculateSummary()

        return (
            <div>
               <form role="form" onSubmit={handleSubmit}>
                   <div className="box-body">
                        <Field readOnly={readOnly} name='name' label='Nome' cols='12 4' placeholder='Informe o nome' type='text'  
                            component={labelAndInput} />
                        <Field readOnly={readOnly} name='month' label='Mês' cols='12 4' placeholder='Informe o mês' type='number'
                            component={labelAndInput} /> 
                        <Field readOnly={readOnly} name='year' label='Ano' cols='12 4'  placeholder='Informe o ano' type='number'
                            component={labelAndInput} />
                        
                        <Summary credit={sumOfCredits} debit={sumOfDebits} />

                        <ItemList field='credits' legend='Créditos' cols='12 6' list={credits} readOnly={readOnly} />
                        <ItemList field='debits'  legend='Débitos'  cols='12 6' list={debits}  readOnly={readOnly} showStatus={true}/>
                   </div>
                   <div className="box-footer">
                       <button type="submit" className={'btn btn-' + this.props.submitClass}>{this.props.submitLabel}</button>
                       <button type="button" className="btn btn-default" onClick={this.props.init}>Cancelar</button>
                   </div>
               </form> 
            </div>
        )
    }
}

BillingCycleForm = reduxForm({form: 'billingCycleForm', destroyOnUnmount: false})(BillingCycleForm)

const selector = formValueSelector('billingCycleForm')
const mapStateToProps = state => ({
        credits: selector(state, 'credits'),
        debits: selector(state, 'debits')
    })
const mapDispatchToProps = dispatch => bindActionCreators({ init }, dispatch)

export default connect(mapStateToProps, mapDispatchToProps)(BillingCycleForm)