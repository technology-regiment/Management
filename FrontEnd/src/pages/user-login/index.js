import React, { Component } from 'react';
import { connect } from 'dva';
import { formatMessage, FormattedMessage } from 'umi/locale';
import Link from 'umi/link';
import { Checkbox, Alert, Icon } from 'antd';
import { Login } from 'ant-design-pro';
import styles from './style.less';

const { Tab, UserName, Password, Mobile, Captcha, Submit } = Login;

@connect(({ userLogin, loading }) => ({
  userLogin,
  submitting: loading.effects['userLogin/login'],
}))


class LoginPage extends Component {
  state = {
    type: 'account'
  };

  onTabChange = type => {
    this.setState({ type });
  };



    login = ( values, callback) => {
      const { dispatch } = this.props;
      dispatch({
        type: 'userLogin/login',
        payload: {
          ...values
        },
        callback
      });
    };

  handleSubmit = (err, values) => {
    const { type } = this.state;
    if (!err) {
      this.login(values , () => {
         message.success("登陆成功");
      });
    }
  };


  renderMessage = content => (
    <Alert style={{ marginBottom: 24 }} message={content} type="error" showIcon />
  );

  render() {
    const { userLogin, submitting } = this.props;
    const { status, type: loginType } = userLogin;
    const { type } = this.state;
    return (
      <div className={styles.main}>
        <Login
          defaultActiveKey={type}
          onTabChange={this.onTabChange}
          onSubmit={this.handleSubmit}
          ref={form => {
            this.loginForm = form;
          }}
        >
          <Tab key="account" tab={formatMessage({ id: 'user-login.login.tab-login-credentials' })}>
            {status === 'error' &&
              !submitting &&
              this.renderMessage(formatMessage({ id: 'user-login.login.message-invalid-credentials' }))}
            <UserName
              name="email"
              placeholder={`${formatMessage({ id: 'Email' })}: 请输入邮箱`}
              rules={[
                {
                  required: true,
                  message: formatMessage({ id: 'validation.Email.required' }),
                },
              ]}
            />

            <Password
              name="password"
              placeholder={`${formatMessage({ id: 'Password' })}: 请输入密码`}
              rules={[
                {
                  required: true,
                  message: formatMessage({ id: 'validation.Password.required' }),
                },
              ]}
              onPressEnter={() => this.loginForm.validateFields(this.handleSubmit)}
            />
          </Tab>
          <Submit loading={submitting}>
            <FormattedMessage id="user-login.login.login" />
          </Submit>
         
        </Login>
      </div>
    );
  }
}

export default LoginPage;
