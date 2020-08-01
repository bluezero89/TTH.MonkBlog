import { Formik } from 'formik';
import i18n from 'i18n-js';
import {
  Container,
  Content,
  Input,
  InputGroup,
  Label,
  ListItem,
  Body,
  Picker,
  Icon,
  Item,
} from 'native-base';
import PropTypes from 'prop-types';
import React, { useRef, useState } from 'react';
import { StyleSheet } from 'react-native';
import * as Yup from 'yup';
import { FormButtons } from '../../components/FormButtons';
import ValidationMessage from '../../components/ValidationMessage/ValidationMessage';
import { usePermission } from '../../hooks/UsePermission';

const validations = {
  name: Yup.string().required('AbpAccount::ThisFieldIsRequired.'),
};

function CreateUpdateTenantForm({ editingTenant = {}, editions = [], submit, remove }) {
  const tenantNameRef = useRef();
  const adminEmailRef = useRef();
  const adminPasswordRef = useRef();

  const [showAdminPassword, setShowAdminPassword] = useState(false);
  const hasRemovePermission = usePermission('Saas.Tenants.Delete');

  const adminEmailAddressValidation = Yup.lazy(() =>
    Yup.string()
      .required('AbpAccount::ThisFieldIsRequired.')
      .email('AbpAccount::ThisFieldIsNotAValidEmailAddress.'),
  );

  const adminPasswordValidation = Yup.lazy(() =>
    Yup.string().required('AbpAccount::ThisFieldIsRequired.'),
  );

  const onSubmit = values => {
    submit({
      ...editingTenant,
      ...values,
    });
  };

  return (
    <Formik
      enableReinitialize
      validationSchema={Yup.object().shape({
        ...validations,
        ...(!editingTenant.id && {
          adminEmailAddress: adminEmailAddressValidation,
          adminPassword: adminPasswordValidation,
        }),
      })}
      initialValues={{
        lockoutEnabled: false,
        twoFactorEnabled: false,
        ...editingTenant,
      }}
      onSubmit={values => onSubmit(values)}>
      {({ handleChange, handleBlur, handleSubmit, values, errors, isValid }) => (
        <>
          <Container style={styles.container}>
            <Content px20>
              <InputGroup abpInputGroup>
                <Label abpLabel>{i18n.t('Saas::TenantName')}</Label>
                <Input
                  abpInput
                  ref={tenantNameRef}
                  onChangeText={handleChange('name')}
                  onBlur={handleBlur('name')}
                  value={values.name}
                />
              </InputGroup>
              <ValidationMessage>{errors.name}</ValidationMessage>
              {editions.length > 0 ? (
                <>
                  <Label abpLabel>{i18n.t('Saas::EditionName')}</Label>
                  <ListItem
                    noIndent
                    icon
                    style={{
                      backgroundColor: '#fff',
                      borderRadius: 15,
                      borderWidth: 1,
                      borderColor: '#e6e6e6',
                    }}>
                    <Body style={{ borderBottomWidth: 0 }}>
                      <Picker
                        mode="dropdown"
                        iosHeader={i18n.t('Saas::Editions')}
                        iosIcon={<Icon active name="arrow-down" />}
                        onValueChange={handleChange('editionId')}
                        selectedValue={values.editionId}
                        textStyle={{ paddingLeft: 0 }}>
                        {editions.map(edition => (
                          <Picker.Item
                            label={edition.displayName}
                            value={edition.id}
                            key={edition.id}
                          />
                        ))}
                      </Picker>
                    </Body>
                  </ListItem>
                </>
              ) : null}
              {!editingTenant.id ? (
                <>
                  <InputGroup abpInputGroup>
                    <Label abpLabel>{i18n.t('Saas::DisplayName:AdminEmailAddress')}</Label>
                    <Input
                      abpInput
                      ref={adminEmailRef}
                      onSubmitEditing={() => adminPasswordRef.current._root.focus()}
                      returnKeyType="next"
                      onChangeText={handleChange('adminEmailAddress')}
                      onBlur={handleBlur('adminEmailAddress')}
                      value={values.adminEmailAddress}
                    />
                  </InputGroup>
                  <ValidationMessage>{errors.adminEmailAddress}</ValidationMessage>
                  <InputGroup abpInputGroup>
                    <Label abpLabel>{i18n.t('Saas::DisplayName:AdminPassword')}</Label>
                    <Item abpInput>
                      <Input
                        ref={adminPasswordRef}
                        returnKeyType="done"
                        secureTextEntry={!showAdminPassword}
                        onChangeText={handleChange('adminPassword')}
                        onBlur={handleBlur('adminPassword')}
                        value={values.adminPassword}
                      />
                      <Icon
                        name={showAdminPassword ? 'eye-off' : 'eye'}
                        onPress={() => setShowAdminPassword(!showAdminPassword)}
                      />
                    </Item>
                  </InputGroup>
                  <ValidationMessage>{errors.adminPassword}</ValidationMessage>
                </>
              ) : null}
            </Content>
          </Container>
          <FormButtons
            submit={handleSubmit}
            remove={remove}
            removeMessage={i18n.t('Saas::TenantDeletionConfirmationMessage', {
              0: editingTenant.name,
            })}
            isSubmitDisabled={!isValid}
            isShowRemove={!!editingTenant.id && hasRemovePermission}
          />
        </>
      )}
    </Formik>
  );
}

CreateUpdateTenantForm.propTypes = {
  editingTenant: PropTypes.object,
  editions: PropTypes.array,
  submit: PropTypes.func.isRequired,
  remove: PropTypes.func.isRequired,
};

const styles = StyleSheet.create({
  container: {
    marginBottom: 50,
  },
});

export default CreateUpdateTenantForm;
