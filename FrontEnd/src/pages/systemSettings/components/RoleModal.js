import { Component } from 'react';
import { Modal, Form, Input } from 'antd';

const FormItem=Form.Item;

class RoleEditModal extends Component{
    constructor(props){
        super(props);
        this.state={
          visible:false,  
        };
    }

    showModelHandler = e => {
        if (e) e.stopPropagation();
        this.setState({
          visible: true,
        });
      };

      hideModelHandler = () => {
        this.setState({
          visible: false,
        });
      };

      okHandler = () => {
        const { onOk } = this.props;
        this.props.form.validateFields((err, values) => {
          if (!err) {
            onOk(values);
            this.hideModelHandler();
          }
        });
      };

    render(){

      const { children } = this.props;
      const { getFieldDecorator } = this.props.form;
      const { Name,Description } = this.props.record;
      const formItemLayout = {
        labelCol: { span: 6 },
        wrapperCol: { span: 14 },
      };

        return(
            <span>
            <span onClick={this.showModelHandler}>{children}</span>
            <Modal
              title="新增/修改角色"
              visible={this.state.visible}
              onOk={this.okHandler}
              onCancel={this.hideModelHandler}
            >
              <Form horizontal onSubmit={this.okHandler}>
                <FormItem {...formItemLayout} label="姓名">
                  {getFieldDecorator('Name', {
                    initialValue: Name,
                  })(<Input />)}
                </FormItem>
                <FormItem
                  {...formItemLayout}label="描述"
                >
                  {
                    getFieldDecorator('Description', {
                      initialValue: Description,
                    })(<Input />)
                  }
                </FormItem>
              </Form>
            </Modal>
          </span>
        );
    }
}

export default Form.create()(RoleEditModal);